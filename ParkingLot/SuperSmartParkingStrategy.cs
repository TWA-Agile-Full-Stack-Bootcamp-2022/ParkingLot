using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SuperSmartParkingStrategy : IParkingStrategy
    {
        public ParkingLot Which(List<ParkingLot> parkingLots)
        {
            // NOTE: the reason we use the FirstOrDefault is in case the parkingLots is an empty list
            var parkingLot = parkingLots.OrderByDescending(parkingLot => (double)parkingLot.NumOfEmptyPositions / ParkingLot.Capacity).FirstOrDefault();
            if (parkingLot == null)
            {
                throw new InvalidOperationException("Not enough position.");
            }
            else
            {
                return parkingLot;
            }
        }
    }
}
