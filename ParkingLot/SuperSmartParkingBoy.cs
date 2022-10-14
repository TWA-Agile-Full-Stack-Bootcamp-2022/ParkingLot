using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        public override Ticket Park(Car car)
        {
            var maxAvailableRate = ManagedParkingLots.Max(parkingLot => parkingLot.AvailableRate());
            var maxAvailableRateParkingLot =
                ManagedParkingLots.First(parkingLot => parkingLot.AvailableRate() == maxAvailableRate);
            return maxAvailableRateParkingLot.Park(car);
        }
    }
}