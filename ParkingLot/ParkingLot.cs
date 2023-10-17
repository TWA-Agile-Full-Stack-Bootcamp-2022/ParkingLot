using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLot
    {
        private int capacity = 10;
        private Dictionary<Ticket, Car> parkingInfo = new Dictionary<Ticket, Car>();

        public ParkingLot()
        {
        }

        public ParkingLot(int capacity)
        {
            this.capacity = capacity;
        }

        public Ticket Park(Car car)
        {
            if (car == null)
            {
                throw new Exception("Car is null.");
            }

            if (parkingInfo.Count >= capacity)
            {
                throw new Exception("Parking lot is full.");
            }

            if (car.IsParked())
            {
                throw new Exception("Car is parked.");
            }

            Ticket ticket = new Ticket();
            parkingInfo.Add(ticket, car);
            car.AddParkingLot(this);
            return ticket;
        }

        public Car PickUp(Ticket ticket)
        {
            if (parkingInfo.ContainsKey(ticket))
            {
                var car = parkingInfo[ticket];
                parkingInfo.Remove(ticket);
                car.RemoveParkingLot();
                return car;
            }

            return null;
        }
    }
}
