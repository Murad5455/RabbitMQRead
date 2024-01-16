using RabbitMQRead.AppContext;
using RabbitMQRead.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMQRead.Base
{
    public class BaseCollector
    {

        public static object ParseMessageToEntity(string message, string exchangeName)
        {
            return exchangeName switch
            {
                "Cdr" => ParseMessageToInfoData<CallInformationDetailed>(message),
                "Sip" => ParseMessageToInfoData<CallInformation>(message),
                _ => throw new ArgumentException($"Unsupported exchange name: {exchangeName}")
            };
        }


        public static void AddEntityToDbContext(ApplicationContext dbContext, object entity)
        {
            if (entity is CallInformationDetailed callInfoDetailed)
            {
                dbContext.CallInformationDetaileds.Add((CallInformationDetailed)entity);
                //  dbContext.Set<CallInformationDetailed>().Add(callInfoDetailed);
            }
            else if (entity is CallInformation callInfo)
            {
                //  dbContext.Set<CallInformation>().Add(callInfo);
                dbContext.CallInformations.Add((CallInformation)entity);

            }
            else
            {
                throw new ArgumentException($"Unsupported entity type: {entity.GetType().Name}");
            }
        }

        static T ParseMessageToInfoData<T>(string message)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(message);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Json deserialization hatası: {ex.Message}");
                return default;
            }
        }



    }
}
