namespace ParkingLot
{
    using System;
    public class Car
    {
        public string LicensePlate { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Car other))
            {
                return false;
            }

            return LicensePlate == other.LicensePlate;
        }

        public override int GetHashCode()
        {
            return LicensePlate.GetHashCode();
        }
    }
}
