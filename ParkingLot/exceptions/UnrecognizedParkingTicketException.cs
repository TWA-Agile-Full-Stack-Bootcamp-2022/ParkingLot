using System;

namespace ParkingLot.Exceptions
{
    public class UnrecognizedParkingTicketException : Exception
    {
        public UnrecognizedParkingTicketException(string message) : base(message)
        {
        }
    }
}
