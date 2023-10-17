using System;

namespace ParkingLot.Exceptions
{
    public class UnrecognizedParkingTicketException : Exception
    {
        public UnrecognizedParkingTicketException() : base("Unrecognized parking ticket.")
        {
        }
    }
}
