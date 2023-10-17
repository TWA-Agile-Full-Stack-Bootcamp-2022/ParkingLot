using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLotManager
    {
        private readonly List<ParkingBoy> parkingBoys;

        public ParkingLotManager(List<ParkingBoy> parkingBoys)
        {
            this.parkingBoys = parkingBoys;
        }

        public Ticket Park(Car car)
        {
            ParkingBoy parkingBoy = FindAvailableParkingBoy();
            return parkingBoy.Park(car);
        }

        private ParkingBoy FindAvailableParkingBoy()
        {
            return null;
        }
    }
}
