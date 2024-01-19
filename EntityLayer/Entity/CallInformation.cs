using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQRead.Entity
{
    public class CallInformation
    {
        public int id { get; set; }
        public DateTimeOffset Date { get; set; }
        public string External { get; set; }
        public string Internal { get; set; }
        public string SipStatus { get; set; }
    }
}
