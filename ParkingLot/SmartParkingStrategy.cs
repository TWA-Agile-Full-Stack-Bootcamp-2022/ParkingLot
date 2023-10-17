using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingStrategy : IParkingStrategy
    {
        public ParkingLot Which(List<ParkingLot> parkingLots)
        {
            // NOTE: the reason we use the FirstOrDefault is in case the parkingLots is an empty list
            var parkingLot = parkingLots.OrderByDescending(parkingLot => parkingLot.NumOfEmptyPositions).FirstOrDefault();
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
