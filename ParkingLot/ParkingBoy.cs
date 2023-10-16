using ParkingLot.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private List<ParkingLot> parkingLots;

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Car Fetch(Ticket givenTicket)
        {
            return null;
        }

        public Ticket Park(Car car)
        {
            ParkingLot availableParkingLot = parkingLots.Find(parkingLot => !parkingLot.IsFull());
            if (availableParkingLot == null)
            {
                throw new NotEnoughPositionException();
            }

            return availableParkingLot.Park(car);
        }
    }
}
