using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public ParkingLot Which(List<ParkingLot> parkingLots)
        {
            // NOTE: FirstOrDefault return null if no expected item, First throw an Exception
            return parkingLots.FirstOrDefault(parkingLot => !parkingLot.IsFull)
                ?? throw new InvalidOperationException("Not enough position.");
        }
    }
}
