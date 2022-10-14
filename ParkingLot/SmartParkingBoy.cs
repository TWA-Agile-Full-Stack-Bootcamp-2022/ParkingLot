using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy
    {
        private List<ParkingLot> managedParkingLots = new List<ParkingLot>();

        public void AddManagedParkingLot(ParkingLot parkingLot)
        {
            managedParkingLots.Add(parkingLot);
        }

        public Ticket Park(Car car)
        {
            var maxCapacity = managedParkingLots.Max(parkingLot => parkingLot.Capacity);
            var maxCapacityParkingLot =
                managedParkingLots.First(parkingLot => parkingLot.Capacity == maxCapacity);
            return maxCapacityParkingLot.Park(car);
        }
    }
}