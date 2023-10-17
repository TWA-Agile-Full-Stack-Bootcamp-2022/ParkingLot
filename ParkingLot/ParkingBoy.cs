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
            return new Ticket(car);
        }
    }
}