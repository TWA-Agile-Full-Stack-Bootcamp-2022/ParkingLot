using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        protected List<Lot> lots = new List<Lot>();

        public ParkingBoy(Lot parkingLot)
        {
            this.lots.Add(parkingLot);
        }

        public ParkingBoy(List<Lot> parkingLots)
        {
            lots = parkingLots;
        }

        public Ticket Parking(Car car)
        {
            foreach (var t in lots.Where(t => t.HasPosition(1)))
            {
                return t.ParkingCar(car);
            }

            throw new LotFullException("Not enough positions.");
        }

        public List<Ticket> Parking(List<Car> cars)
        {
            return cars.Select(Parking).ToList();
        }

        public Car PickUp(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ParkingException("Please provide your parking ticket.");
            }

            var car = lots.Select(lot => lot.PickUpCar(ticket)).FirstOrDefault(car => car != null);

            if (car == null)
            {
                throw new ParkingException("Unrecognized parking ticket.");
            }

            return car;
        }
    }
}