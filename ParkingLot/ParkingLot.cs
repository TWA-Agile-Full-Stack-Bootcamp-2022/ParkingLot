namespace ParkingLot
{
    public class ParkingLot
    {
        public ParkingLot(int capacity)
        {
            Capacity = capacity;
        }

        public int Capacity { get; set; }

        public Ticket Park(Car car)
        {
            return new Ticket();
        }
    }
}