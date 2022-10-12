using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private Lot lot;

        public ParkingBoy(Lot parkingLot)
        {
            this.lot = parkingLot;
        }

        public Ticket Parking(Car car)
        {
            return lot.ParkingCar(car);
        }

        public List<Ticket> Parking(List<Car> cars)
        {
            var tickets = cars.Select(t => new Ticket(t)).ToList();
            lot.ParkingCar(cars, tickets);
            return tickets;
        }

        public Car PickUp(Ticket ticket)
        {
            if (ticket == null)
            {
                return null;
            }

            var car = lot.PickUpCar(ticket);
            return car;
        }
    }
}