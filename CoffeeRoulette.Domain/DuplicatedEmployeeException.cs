using System;
using System.Runtime.Serialization;

namespace CoffeeRoulette.Domain
{
    public class DuplicatedEmployeeException : Exception
    {
        public DuplicatedEmployeeException()
        {
        }

        public DuplicatedEmployeeException(string message) : base(message)
        {
        }

        public DuplicatedEmployeeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicatedEmployeeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
