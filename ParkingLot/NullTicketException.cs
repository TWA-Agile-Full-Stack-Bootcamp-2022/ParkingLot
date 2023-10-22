using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class NullTicketException : Exception
    {
        public NullTicketException()
        {
        }

        public NullTicketException(string message) : base(message)
        {
        }

        public NullTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NullTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}