namespace ParkingLot
{
    public class Car
    {
        public Car(string plateNumber)
        {
            PlateNumber = plateNumber;
        }

        public string PlateNumber { get; }

        public override bool Equals(object obj)
        {
            var car = obj as Car;
            return car != null && PlateNumber.Equals(car.PlateNumber);
        }

        public override int GetHashCode()
        {
            return PlateNumber != null ? PlateNumber.GetHashCode() : 0;
        }

        protected bool Equals(Car other)
        {
            return PlateNumber == other.PlateNumber;
        }
    }
}