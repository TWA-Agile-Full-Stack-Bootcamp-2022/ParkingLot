using System.Collections.Generic;

namespace ParkingLot
{
    public class Lot
    {
        private Dictionary<Ticket, Car> lotSpace = new Dictionary<Ticket, Car>();

        public void ParkingCar(Car car, Ticket ticket)
        {
            lotSpace.Add(ticket, car);
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
            return lotSpace[ticket];
        }
    }
}