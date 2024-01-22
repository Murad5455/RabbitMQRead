using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQRead.AppContext;
using RabbitMQRead.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RabbitMQRead.Base
{
    public class CdrSipService
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationContext _context;

        public CdrSipService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = new ApplicationContext(configuration);
        }
       

        public object ParseMessageToEntity(string message, string exchangeName)
        {
            var sipCdrSettings = _configuration.GetSection("SipCdrSettings");
           
            string sipExchange = sipCdrSettings["SipExchange"];
            string cdrExchange = sipCdrSettings["CdrExchange"];

            string[] validExchangeNames = { sipExchange, cdrExchange };


            return exchangeName switch
            {

                _ when exchangeName == cdrExchange => ParseMessageToInfoData<CallInformationDetailed>(message),
                _ when exchangeName == sipExchange => ParseMessageToInfoData<CallInformation>(message),
                _ => throw new ArgumentException($"Unsupported exchange name: {exchangeName}")
            };
        }

        public static void AddEntityToDbContext(ApplicationContext dbContext, object entity)
        {
            if (entity is CallInformationDetailed callInfoDetailed)
            {
                
                callInfoDetailed.Date = ToUtcDateTime(callInfoDetailed.Date);
                dbContext.CallInformationDetaileds.Add(callInfoDetailed);
            }
            else if (entity is CallInformation callInfo)
            {
                
                callInfo.Date = ToUtcDateTime(callInfo.Date);
                dbContext.CallInformations.Add(callInfo);
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
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new DateTimeOffsetConverter() }
                };

                return System.Text.Json.JsonSerializer.Deserialize<T>(message, options);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine($"Json deserialization hatası: {ex.Message}");
                return default;
            }
        }

        private static DateTimeOffset ToUtcDateTime(DateTimeOffset? dateTimeOffset)
        {
            return dateTimeOffset?.UtcDateTime ?? DateTimeOffset.MinValue;
        }
    }

    public class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.Parse(reader.GetString(), null, DateTimeStyles.AssumeUniversal);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("O")); 
        }
    }
}
