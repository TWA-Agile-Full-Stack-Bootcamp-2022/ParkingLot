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

        public Car PickUpCar(Ticket ticket)
        {
            return lotSpace[ticket];
        }
    }
}