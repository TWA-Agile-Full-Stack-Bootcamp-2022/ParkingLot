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
                throw new NoTicketProvidedException();
            }

            if (!ticketCarPairs.ContainsKey(ticketRecived))
            {
                throw new UnrecognizedParkingTicketException();
            }

            Car fetchedCar = ticketCarPairs[ticketRecived];
            ticketCarPairs.Remove(ticketRecived);
            return fetchedCar;
        }

        public bool HasTicket(Ticket ticket)
        {
            return ticketCarPairs.ContainsKey(ticket);
        }

        public virtual bool IsFull()
        {
            return ticketCarPairs.Count == MaxCapacity;
        }

        public virtual Ticket Park(Car car)
        {
            if (IsFull())
            {
                throw new NotEnoughPositionException();
            }

            Ticket ticket = new Ticket();
            ticketCarPairs.Add(ticket, car);
            return ticket;
        }
    }
}
