using ParkingLot.Exceptions;
using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        public const int MaxCapacity = 10;
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
            if (ticketRecived == null)
            {
                throw new NoTicketProvidedException("Please provide your parking ticket.");
            }

            if (!ticketCarPairs.ContainsKey(ticketRecived))
            {
                throw new UnrecognizedParkingTicketException("Unrecognized parking ticket.");
            }

            Car fetchedCar = ticketCarPairs[ticketRecived];
            ticketCarPairs.Remove(ticketRecived);
            return fetchedCar;
        }

        public bool IsFull()
        {
            return ticketCarPairs.Count == MaxCapacity;
        }

        public virtual Ticket Park(Car car)
        {
            if (IsFull())
            {
                throw new NotEnoughPositionException("Not enough position.");
            }

            Ticket ticket = new Ticket();
            ticketCarPairs.Add(ticket, car);
            return ticket;
        }
    }
}
