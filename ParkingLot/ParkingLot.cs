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
            Capacity--;
            return new Ticket();
        }

        public Car Pickup(Ticket ticket)
        {
            Capacity++;
            return new Car("江AB1234");
        }
    }
}