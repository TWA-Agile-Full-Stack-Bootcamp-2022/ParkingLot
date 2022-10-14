using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        private Dictionary<Ticket, Car> parkingCars;

        public ParkingLot(int capacity)
        {
            Capacity = capacity;
            parkingCars = new Dictionary<Ticket, Car>();
        }

        public int Capacity { get; set; }

        public Ticket Park(Car car)
        {
            CheckCapacity();

            CheckDuplicateCars(car);

            return ParkANewCar(car);
        }

        public Car Pickup(Ticket ticket)
        {
            CheckTicket(ticket);

            return PickupCarByTicket(ticket);
        }

        private Car PickupCarByTicket(Ticket ticket)
        {
            Capacity++;
            var pickedCar = parkingCars[ticket];
            parkingCars.Remove(ticket);
            return pickedCar;
        }

        private void CheckTicket(Ticket ticket)
        {
            if (ticket == null || !parkingCars.ContainsKey(ticket))
            {
                throw new IllegalTicketException();
            }
        }

        private Ticket ParkANewCar(Car car)
        {
            var ticket = new Ticket();
            parkingCars[ticket] = car;
            Capacity--;
            return ticket;
        }

        private void CheckDuplicateCars(Car car)
        {
            if (parkingCars.ContainsValue(car))
            {
                throw new DuplicateCarException();
            }
        }

        private void CheckCapacity()
        {
            if (Capacity <= 0)
            {
                throw new NoAvailablePositionException();
            }
        }
    }
}