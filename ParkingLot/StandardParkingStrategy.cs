using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class StandardParkingStrategy : IParkingStrategy
    {
        public ParkingLot Which(List<ParkingLot> parkingLots)
        {
            return parkingLots.First();
        }
    }
}
