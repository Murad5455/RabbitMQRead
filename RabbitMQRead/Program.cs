
using RabbitMQRead.CdrCollector;
using RabbitMQRead.SipCollector;
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
       
        Task sipTask = Task.Run(() => Sip.StartSip());
        Task cdrTask = Task.Run(() => Cdr.StartCdr());
       
        Task.WaitAll(sipTask, cdrTask);
    
    }
}

