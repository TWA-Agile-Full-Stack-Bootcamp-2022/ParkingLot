using System.Collections.Generic;

namespace ParkingLot
{
    public class Lot
    {
        private Dictionary<Ticket, Car> lotSpace = new Dictionary<Ticket, Car>();
        private int size;
        public Lot(int i)
        {
            size = i;
        }

        public Lot()
        {
        }

        public Ticket ParkingCar(Car car)
        {
            if (size != 0 && lotSpace.Count >= size)
            {
                return null;
            }

            var ticket = new Ticket(car);
            lotSpace.Add(ticket, car);
            return ticket;
        }

        public void ParkingCar(List<Car> cars, List<Ticket> tickets)
        {
            for (var i = 0; i < tickets.Count; i++)
            {
                lotSpace.Add(tickets[i], cars[i]);
            }
        }

        public Car PickUpCar(Ticket ticket)
        {
            if (!lotSpace.ContainsKey(ticket))
            {
                return null;
            }

            var pickUpCar = lotSpace[ticket];
            lotSpace.Remove(ticket);
            return pickUpCar;
        }
    }
}