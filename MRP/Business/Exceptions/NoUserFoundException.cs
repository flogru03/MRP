using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business
{
    internal class NoUserFoundException : Exception
    {
        public NoUserFoundException()
        {
        }

        public NoUserFoundException(string? message) : base(message)
        {
        }

        public NoUserFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
