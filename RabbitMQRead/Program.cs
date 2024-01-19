
/*using RabbitMQRead.Base;
using RabbitMQRead.CdrCollector;*/
using RabbitMQRead.SipCdrCollector;
//using RabbitMQRead.SipCollector;
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Collector.StartCollector();
       
    
    }
}

