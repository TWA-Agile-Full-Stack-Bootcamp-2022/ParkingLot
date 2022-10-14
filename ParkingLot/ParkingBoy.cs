using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> managedParkingLots = new List<ParkingLot>();

        public void AddManagedParkingLot(ParkingLot parkingLot)
        {
            managedParkingLots.Add(parkingLot);
        }

        public Ticket Park(Car car)
        {
            foreach (var parkingLot in managedParkingLots.Where(t => t.Capacity > 0))
            {
                return parkingLot.Park(car);
            }

            throw new NoAvailablePositionException("Not enough position.");
        }
    }
}