using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message) { }
        public SuccessResult(string message,string logMessage) : base(true, message,logMessage) { }
        public SuccessResult() : base(true) { }

    }
}
