using System;

namespace ParkingLot
{
    public class NoAvailablePositionException : Exception
    {
        public NoAvailablePositionException(string message) : base(message)
        {
        }
    }
}