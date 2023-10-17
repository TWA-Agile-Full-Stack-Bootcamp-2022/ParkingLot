using System.Collections.Generic;

namespace ParkingLot
{
    public interface IParkingStrategy
    {
        public ParkingLot Which(List<ParkingLot> parkingLots);
    }
}
