using ParkingLot.Exceptions;
using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        public const int DefaultCapacity = 10;

        private Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();

        public ParkingLot()
        {
        }

        public ParkingLot(int capacity)
        {
            Capacity = capacity;
        }

        public ParkingLot(Dictionary<Ticket, Car> ticketCarPairs)
        {
            this.ticketCarPairs = ticketCarPairs;
        }

        public ParkingLot(Dictionary<Ticket, Car> ticketCarPairs, int capacity) : this(ticketCarPairs)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; } = DefaultCapacity;

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

        public float GetAvailablePositionRate()
        {
            return (float)(Capacity - ticketCarPairs.Count) / Capacity;
        }

        public int GetPositionLeft()
        {
            return Capacity - ticketCarPairs.Count;
        }

        public bool HasTicket(Ticket ticket)
        {
            return ticketCarPairs.ContainsKey(ticket);
        }

        public virtual bool IsFull()
        {
            return ticketCarPairs.Count == DefaultCapacity;
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
