using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SuperSmartParkingBoy
    {
        private List<ParkingLot> managedParkingLots = new List<ParkingLot>();

        public void AddManagedParkingLot(ParkingLot parkingLot)
        {
            managedParkingLots.Add(parkingLot);
        }

        public Ticket Park(Car car)
        {
            var maxAvailableRate = managedParkingLots.Max(parkingLot => parkingLot.AvailableRate());
            var maxAvailableRateParkingLot =
                managedParkingLots.First(parkingLot => parkingLot.AvailableRate() == maxAvailableRate);
            return maxAvailableRateParkingLot.Park(car);
        }
    }
}