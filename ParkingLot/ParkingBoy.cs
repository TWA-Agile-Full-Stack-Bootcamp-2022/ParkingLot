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
            CheckManagedParkingLots();

            foreach (var parkingLot in ManagedParkingLots.Where(t => t.Capacity > 0))
            {
                return parkingLot.Park(car);
            }

            throw new NoAvailablePositionException("Not enough position.");
        }

        public Car Fetch(Ticket ticket)
        {
            CheckManagedParkingLots();

            var parkingLot = ManagedParkingLots.FirstOrDefault(parkingLot => parkingLot.ContainsTicket(ticket));
            if (parkingLot == null)
            {
                throw new IllegalTicketException("Unrecognized parking ticket.");
            }

            return parkingLot.Fetch(ticket);
        }

        protected void CheckManagedParkingLots()
        {
            if (ManagedParkingLots.Count == 0)
            {
                throw new NoParkingLotsManagedException();
            }
        }
    }
}