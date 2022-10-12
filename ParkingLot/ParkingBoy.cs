namespace ParkingLot
{
    public class ParkingBoy
    {
        private Lot lot;
        public ParkingBoy(Lot parkingLot)
        {
            this.lot = parkingLot;
        }

        public Ticket Parking(Car car)
        {
           return new Ticket(car);
        }
    }
}