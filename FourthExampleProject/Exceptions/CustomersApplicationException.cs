namespace Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// Main Exception Class
    /// </summary>
    [Serializable]
    public abstract class CustomersApplicationException : Exception
    {
        public static string CustomMessage = "Customers Registration System Main Exception.";

        public CustomersApplicationException() : base()
        {
        }

        public CustomersApplicationException(string message)
            : base(message)
        {
        }

        public CustomersApplicationException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public CustomersApplicationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public CustomersApplicationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected CustomersApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}