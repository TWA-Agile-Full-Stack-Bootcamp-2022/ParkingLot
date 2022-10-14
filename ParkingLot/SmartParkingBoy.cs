using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public override Ticket Park(Car car)
        {
            var maxCapacity = ManagedParkingLots.Max(parkingLot => parkingLot.Capacity);
            var maxCapacityParkingLot =
                ManagedParkingLots.First(parkingLot => parkingLot.Capacity == maxCapacity);
            return maxCapacityParkingLot.Park(car);
        }
    }
}