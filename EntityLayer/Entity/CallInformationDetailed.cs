using System.ComponentModel.DataAnnotations.Schema;
using static EntityLayer.ResultEnum.InfoEnum;

namespace RabbitMQRead.Entity
{
    public class CallInformationDetailed:CallInformationShort
    {
        [ForeignKey("Id")]
        public int Id { get; set; }

        public string? CallId { get; set; }

        public DateTimeOffset? Date { get; set; }

        public DateTimeOffset? CallStarted { get; set; }

        public DateTimeOffset? CallStartedTest { get; set; }

        public DateTimeOffset? CallEnded { get; set; }

        public DateTimeOffset? CallAnswered { get; set; }

        public string? GatewayName { get; set; }

        public string? IsMakeCall { get; set; }

        public string? Chain { get; set; }

        public string? ReasonTerminated { get; set; }

        public string? ReasonChanged { get; set; }

        public CallType CallType { get; set; }


        [NotMapped]
        public string NotMappedCallStarted { get; set; }

        [NotMapped]
        public string NotMappedCallEnded { get; set; }

        [NotMapped]
        public string NotMappedCallAnswered { get; set; }




    }
}