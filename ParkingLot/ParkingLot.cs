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
            var ticket = new Ticket();
            parkingCars[ticket] = car;
            Capacity--;
            return ticket;
        }

        public Car Pickup(Ticket ticket)
        {
            if (parkingCars.ContainsKey(ticket))
            {
                Capacity++;
                var pickedCar = parkingCars[ticket];
                parkingCars.Remove(ticket);
                return pickedCar;
            }

            return new Car("江AB1234");
        }
    }
}