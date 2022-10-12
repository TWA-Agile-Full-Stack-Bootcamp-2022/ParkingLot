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
            var ticket = new Ticket(car);
            lot.ParkingCar(car, ticket);
            return ticket;
        }

        public List<Ticket> Parking(List<Car> cars)
        {
            return cars.Select(t => new Ticket(t)).ToList();
        }

        public Car PickUp(Ticket ticket)
        {
            var car = lot.PickUpCar(ticket);
            return car;
        }
    }
}