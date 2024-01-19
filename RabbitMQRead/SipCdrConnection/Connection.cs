using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQRead.AppContext;
using RabbitMQRead.Base;


namespace RabbitMQRead.SipCdrCollector
{
    public class Connection: CdrSipService
    {
        private static readonly string RabbitMQHost = "localhost";

        public static void StartCollector()
        {
            var factory = new ConnectionFactory
            {
                UserName = "guest",
                Password = "guest",
                HostName = RabbitMQHost
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                SetupRabbitMQ(channel, "Sip", "Cdr", "CollectorQueue");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var exchangeName = ea.Exchange;

                        Console.WriteLine($"[x] Received message from exchange '{exchangeName}': {message}");

                        var entity = ParseMessageToEntity(message, exchangeName);

                        using (var dbContext = new ApplicationContext())
                        {
                            AddEntityToDbContext(dbContext, entity);
                            dbContext.SaveChanges();
                        }



                        Console.WriteLine("[x] Message processed.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[!] Error processing message: {ex.Message}");
                    }
                };

                channel.BasicConsume(queue: "CollectorQueue", autoAck: true, consumer: consumer);

                Console.WriteLine("[x] Waiting for messages. To exit press CTRL+C");
                Console.ReadLine();
            }
        }

        private static void SetupRabbitMQ(IModel channel, string sipExchange, string cdrExchange, string queueName)
        {
            channel.ExchangeDeclare(exchange: sipExchange, type: ExchangeType.Direct, durable: true);
            channel.ExchangeDeclare(exchange: cdrExchange, type: ExchangeType.Fanout, durable: true);

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            
            channel.QueueBind(queue: queueName, exchange: sipExchange, routingKey: "");
            channel.QueueBind(queue: queueName, exchange: cdrExchange, routingKey: "");
        }
    }
}
