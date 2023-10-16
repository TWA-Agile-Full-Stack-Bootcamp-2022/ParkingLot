using System;

namespace ParkingLot.Exceptions
{
    public class NotEnoughPositionException : Exception
    {
        public NotEnoughPositionException() : base("Not enough position.")
        {
        }
    }
}
