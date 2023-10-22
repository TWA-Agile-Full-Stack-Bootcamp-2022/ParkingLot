﻿using System;
using System.Runtime.Serialization;

namespace ParkingLot
{
    [Serializable]
    public class InvalidTicketException : Exception
    {
        public InvalidTicketException()
        {
        }

        public InvalidTicketException(string message) : base(message)
        {
        }

        public InvalidTicketException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTicketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}