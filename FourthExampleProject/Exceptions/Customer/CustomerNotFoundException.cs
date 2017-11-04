namespace Exceptions.Customer
{
    using System;
    using System.Runtime.Serialization;
    
    /// <summary>
    /// Main User Exception
    /// </summary>
    [Serializable]
    public class CustomerNotFoundException : CustomersApplicationException
    {
        public static new string CustomMessage = "Customer is not found in the database";

        public CustomerNotFoundException() : base()
        {
        }

        public CustomerNotFoundException(string message)
            : base(message)
        {
        }

        public CustomerNotFoundException(string format, params object[] args)
            : base(string.Format(format, args))
        {
        }

        public CustomerNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public CustomerNotFoundException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected CustomerNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}