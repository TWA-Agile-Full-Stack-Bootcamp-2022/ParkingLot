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
            ParkingBoy parkingBoyAvailable = parkingBoys.Find(parkingBoy => parkingBoy.HasAvailableParkingLot());
            if (parkingBoyAvailable == null)
            {
                // Needs to clarify requirements: no Available parking boy ?
                return null;
            }

            return parkingBoyAvailable;
        }
    }
}
