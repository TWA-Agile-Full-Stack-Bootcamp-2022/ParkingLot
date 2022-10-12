using System;

namespace ParkingLot
{
    public class LotFullException : Exception
    {
        public LotFullException(string message) : base(message)
        {
        }
    }
}