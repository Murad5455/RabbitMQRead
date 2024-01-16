using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ResultEnum
{
    public class InfoEnum
    {
        public enum DialResult
        {
            None = 0,
            Ringing =10,
            Seccess =1,
            Busy =2,
            NotAnswered = 3,
            NotReachable = 4,
            AnswereByClient = 5,
            AnswereByExtension = 7,
            MissedCall = 6,
            InvalidNumber = 11,
            CallDurationLessThanExpected = 12,
            TimeOut =13
 
        }
        public enum CallType
        {
           External = 0,
           Internal = 1
        }
    }
}
