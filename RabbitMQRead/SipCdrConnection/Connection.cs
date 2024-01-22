using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQRead.AppContext;
using RabbitMQRead.Base;
using Serilog;

namespace RabbitMQRead.SipCdrCollector
{
    public class Connection : CdrSipService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext _context;
        private static readonly string RabbitMQHost = "localhost";

        public Connection(IConfiguration configuration, ApplicationContext context)
            : base(configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
  
        public void StartCollector()
        {
            Log.Information("StartCollector islemeye basladi");
            var rabbitMqSettings = _configuration.GetSection("RabbitMQConnection");
            var sipCdrSettings = _configuration.GetSection("SipCdrSettings");

            var factory = new ConnectionFactory
            {
                HostName = rabbitMqSettings["HostName"],
                UserName = rabbitMqSettings["UserName"],
                Password = rabbitMqSettings["Password"],
            };



            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                SetupRabbitMQ(channel, sipCdrSettings["SipExchange"], sipCdrSettings["CdrExchange"], "CollectorQueue");

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

                        AddEntityToDbContext(_context, entity);
                        _context.SaveChanges();
                        Log.Information($"{exchangeName} Database yazildi");
                        Console.WriteLine("[x] Message processed.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[!] Error processing message: {ex.Message}");
                        Log.Error(ex, "Proses zamani xeta bas verdi");
                    }
                };

                channel.BasicConsume(queue: "CollectorQueue", autoAck: true, consumer: consumer);

                Console.WriteLine("[x] Waiting for messages. To exit press CTRL+C");
                Log.Information("RabbitMQ-nu dinlemeye baslayib");
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
