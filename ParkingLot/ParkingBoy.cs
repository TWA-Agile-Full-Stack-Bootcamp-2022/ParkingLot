using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public void AddParkingLot(ParkingLot parkingLot)
        {
            parkingLots.Add(parkingLot);
        }

        public Ticket Park(Car car)
        {
            return parkingLots[0].Park(car);
        }

        public Car PickUp(Ticket ticket)
        {
            var car = parkingLots[0].PickUp(ticket);
            if (car == null)
            {
                throw new Exception("Unrecognized parking ticket.");
            }

            return car;
        }
    }
}