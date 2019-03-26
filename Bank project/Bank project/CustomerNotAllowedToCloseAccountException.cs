using System;
using System.Runtime.Serialization;

namespace Bank_project
{
    [Serializable]
    public class CustomerNotAllowedToCloseAccountException : ApplicationException
    {
        public CustomerNotAllowedToCloseAccountException()
        {
        }

        public CustomerNotAllowedToCloseAccountException(string message) : base(message)
        {
        }

        public CustomerNotAllowedToCloseAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotAllowedToCloseAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}