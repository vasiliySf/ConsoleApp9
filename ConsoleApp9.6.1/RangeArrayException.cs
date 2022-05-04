using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionSample
{
    internal class RangeArrayException : Exception
    {
        public RangeArrayException() : base() { }
        public RangeArrayException(string message) : base(message) { }
        public RangeArrayException(string message, Exception innerException) : base(message, innerException) { }

        //public RangeArrayException()
        public override string ToString()
        {
            return Message;
            //base.ToString();
        }
    }
}
