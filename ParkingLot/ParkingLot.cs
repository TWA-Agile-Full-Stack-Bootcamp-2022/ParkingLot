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

        public virtual Car Fetch(Ticket ticketRecived)
        {
            if (ticketRecived == null || !ticketCarPairs.ContainsKey(ticketRecived))
            {
                return null;
            }

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
