using System;

namespace ParkingLot.Exceptions
{
    public class NoTicketProvidedException : Exception
    {
        public NoTicketProvidedException() : base("Please provide your parking ticket.")
        {
        }
    }
}
