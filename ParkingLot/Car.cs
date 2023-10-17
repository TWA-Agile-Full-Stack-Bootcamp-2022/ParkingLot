namespace ParkingLot
{
    public class Car
    {
        private ParkingLot parkingLot;

        public bool IsParked() => parkingLot != null;

        public void AddParkingLot(ParkingLot parkingLot)
        {
            this.parkingLot = parkingLot;
        }

        public void RemoveParkingLot()
        {
            this.parkingLot = null;
        }
    }
}