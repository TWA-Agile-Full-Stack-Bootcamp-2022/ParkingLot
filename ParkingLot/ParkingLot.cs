using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        private Dictionary<Ticket, Car> parkingInfo = new Dictionary<Ticket, Car>();

        public Ticket Park(Car car)
        {
            Ticket ticket = new Ticket();
            parkingInfo.Add(ticket, car);
            return ticket;
        }

        public Car PickUp(Ticket ticket)
        {
            if (parkingInfo.ContainsKey(ticket))
            {
                var car = parkingInfo[ticket];
                parkingInfo.Remove(ticket);
                return car;
            }

            return null;
        }
    }
}
