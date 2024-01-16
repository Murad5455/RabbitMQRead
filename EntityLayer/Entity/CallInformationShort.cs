using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityLayer.ResultEnum.InfoEnum;

namespace RabbitMQRead.Entity
{
    public class CallInformationShort
    {

        public int? CallDuraction { get; set; }

        public string? Internal { get; set; }

        public string? SipStatusRecived { get; set; }

        public string? SipStatus { get; set; }

        public string? External { get; set; }

        public DialResult? DialResult { get; set; }

        public string? CustomerId { get; set; }

        public string? Cif { get; set; }

    }
}
