using System.ComponentModel.DataAnnotations.Schema;
using static EntityLayer.ResultEnum.InfoEnum;

namespace RabbitMQRead.Entity
{
    public class CallInformationDetailed:CallInformationShort
    {
        [ForeignKey("Id")]
        public int Id { get; set; }

        public string? CallId { get; set; }

        public DateTime? Date { get; set; }

        public string? CallStarted { get; set; }

        public string? CallEnded { get; set; }

        public string? CallAnswered { get; set; }

        public string? GatewayName { get; set; }

        public string? IsMakeCall { get; set; }

        public string? Chain { get; set; }

        public string? ReasonTerminated { get; set; }

        public string? ReasonChanged { get; set; }

        public CallType CallType { get; set; }


    }
}