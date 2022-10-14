using System;

namespace ParkingLot
{
    public class IllegalTicketException : Exception
    {
        public IllegalTicketException(string message) : base(message)
        {
        }
    }
}