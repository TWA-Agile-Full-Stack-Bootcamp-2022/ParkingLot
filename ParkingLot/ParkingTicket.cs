namespace ParkingLot
{
    using System;

    public class ParkingTicket
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string LicensePlate { get; set; }

        public bool Used { get; set; } = false;

        public bool Issued { get; set; } = false;

        public override bool Equals(object obj)
        {
            if (!(obj is ParkingTicket other))
            {
                return false;
            }

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return LicensePlate.GetHashCode();
        }

        public void Issue(string licensePlate)
        {
            LicensePlate = licensePlate;
            Used = false;
            Issued = true;
        }

        public void Retrieve()
        {
            LicensePlate = null;
            Used = true;
            Issued = false;
        }
    }
}
