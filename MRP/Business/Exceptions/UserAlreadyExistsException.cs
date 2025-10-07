using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business
{
    internal class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException()
        {
        }

        public UserAlreadyExistsException(string? message) : base(message)
        {
        }

        public UserAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
