using System;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot;

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public Car Fetch(Ticket givenTicket)
        {
            return parkingLot.Fetch(givenTicket);
        }

        public Ticket Park(Car car)
        {
            return parkingLot.Park(car);
        }
    }
}
