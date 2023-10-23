using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class InsufficientPositionException : Exception
    {
        public InsufficientPositionException()
        {
        }

        public InsufficientPositionException(string message) : base(message)
        {
        }

        public InsufficientPositionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientPositionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}