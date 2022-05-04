using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayException
{
    internal class FormatInputException :Exception
    {
        public FormatInputException() : base() { }
        public FormatInputException(string message) : base(message) { }
        public FormatInputException(string message, Exception innerException) : base(message, innerException) { }
                
        public override string ToString()
        {
            return Message;
        }
    }
}
