using System;

namespace ParkingLot.Exceptions
{
    public class NoTicketProvidedException : Exception
    {
        public NoTicketProvidedException(string message) : base(message)
        {
        }
    }
}
