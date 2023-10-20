namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingBoy
    {
        private readonly Dictionary<string, string> parkingLot = new Dictionary<string, string>();
        public string Park(string car)
        {
            string ticket = car + "ticket";
            parkingLot.Add(ticket, car);
            return ticket;
        }

        public string Fetch(string ticket)
        {
            if (ticket == null || !parkingLot.ContainsKey(ticket))
            {
                return null;
            }

            string car = parkingLot[ticket];
            parkingLot.Remove(ticket);
            return car;
        }
    }
}
