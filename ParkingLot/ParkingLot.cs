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

        public Car Fetch(Ticket ticket)
        {
            CheckTicket(ticket);

            return FetchCarByTicket(ticket);
        }

        public decimal AvailableRate()
        {
            var allPositionsCount = parkingCars.Count + Capacity;
            return allPositionsCount == 0 ? 0 : Capacity / (decimal)allPositionsCount;
        }

        public bool ContainsTicket(Ticket ticket)
        {
            return parkingCars.ContainsKey(ticket);
        }

        private Car FetchCarByTicket(Ticket ticket)
        {
            Capacity++;
            var fetchedCar = parkingCars[ticket];
            parkingCars.Remove(ticket);
            return fetchedCar;
        }

        private void CheckTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new IllegalTicketException("Please provide your parking ticket.");
            }

            if (!parkingCars.ContainsKey(ticket))
            {
                throw new IllegalTicketException("Unrecognized parking ticket.");
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
                throw new NoAvailablePositionException("Not enough position.");
            }
        }
    }
}