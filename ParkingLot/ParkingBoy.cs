using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        protected List<ParkingLot> ManagedParkingLots { get; } = new List<ParkingLot>();

        public void AddManagedParkingLot(ParkingLot parkingLot)
        {
            ManagedParkingLots.Add(parkingLot);
        }

        public virtual Ticket Park(Car car)
        {
            foreach (var parkingLot in ManagedParkingLots.Where(t => t.Capacity > 0))
            {
                return parkingLot.Park(car);
            }

            throw new NoAvailablePositionException("Not enough position.");
        }
    }
}