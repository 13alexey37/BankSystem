using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferDataClassLibrary.Net
{
    public class ResponseWrapper
    {
        public enum StatusEnum
        {
            Ok,
            LogicError,
            SystemError
        }

        public StatusEnum Status { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"\nStatus = {Status}\nMessage = {Message}";
        }
    }
}
