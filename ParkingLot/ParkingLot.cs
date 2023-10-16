using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        private Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();

        public ParkingLot()
        {
        }

        public ParkingLot(Dictionary<Ticket, Car> ticketCarPairs)
        {
            this.ticketCarPairs = ticketCarPairs;
        }

        public Car Fetch(Ticket ticketRecived)
        {
            return ticketCarPairs[ticketRecived];
        }

        public virtual Ticket Park(Car car)
        {
            Ticket ticket = new Ticket();
            ticketCarPairs.Add(ticket, car);
            return ticket;
        }
    }
}
