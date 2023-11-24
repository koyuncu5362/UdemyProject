using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;
        }
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }
        public Result(bool success, string message,string logMessage) : this(success)
        {
            Message = message;
            LogMessage = logMessage;
        }


        public bool Success { get; }

        public string Message { get; }
        public string LogMessage { get;  }
    }
}
