namespace ParkingLot
{
    public class Ticket
    {
        private Car car;
        public Ticket(Car car)
        {
            this.car = car;
        }

        public Car GetCar()
        {
            return car;
        }
    }
}