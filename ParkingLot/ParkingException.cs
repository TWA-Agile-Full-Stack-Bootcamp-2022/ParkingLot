using System;

namespace ParkingLot
{
    public class ParkingException : Exception
    {
        public ParkingException(string message) : base(message)
        {
        }
    }
}