using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots = new List<ParkingLot>();
        public void AddParkingLot(ParkingLot parkingLot)
        {
            parkingLots.Add(parkingLot);
        }

        public List<ParkingLot> GetParkingLots() => parkingLots;

        public virtual ParkingLot FindParkingLot()
        {
            return this.GetParkingLots().Find(parkingLot => parkingLot.LeftPosition > 0);
        }

        public Ticket Park(Car car)
        {
            var parkingLot = FindParkingLot();
            if (parkingLot == null)
            {
                throw new Exception("Not enough position.");
            }

            return parkingLot.Park(car);
        }

        public Car PickUp(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new Exception("Please provide your parking ticket.");
            }

            var car = parkingLots.Select(parkingLot => parkingLot.PickUp(ticket)).FirstOrDefault(c => c != null);

            if (car == null)
            {
                throw new Exception("Unrecognized parking ticket.");
            }

            return car;
        }
    }
}