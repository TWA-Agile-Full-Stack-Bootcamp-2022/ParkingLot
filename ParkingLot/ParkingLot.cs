namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    internal class ParkingLot
    {
        private readonly Dictionary<string, string> parkingLot = new Dictionary<string, string>();
        private int capacity = 10;

        public int Capacity { get => capacity; set => capacity = value; }

        public string Park(string car)
        {
            if (car == null)
            {
                return null;
            }

            if (parkingLot.Count >= capacity)
            {
                throw new InsufficientPositionException("Not enough position");
            }

            if (parkingLot.ContainsValue(car))
            {
                foreach (var item in parkingLot)
                {
                    if (item.Value.Equals(car))
                    {
                        return item.Key;
                    }
                }
            }

            string ticket = car + "ticket";
            parkingLot.Add(ticket, car);
            return ticket;
        }

        public string Fetch(string ticket)
        {
            if (ticket == null)
            {
                throw new NullTicketException("Please provide your parking ticket");
            }

            if (!parkingLot.ContainsKey(ticket))
            {
                throw new NullTicketException("Unrecognized parking ticket");
            }

            string car = parkingLot[ticket];
            parkingLot.Remove(ticket);
            return car;
        }
    }
}
