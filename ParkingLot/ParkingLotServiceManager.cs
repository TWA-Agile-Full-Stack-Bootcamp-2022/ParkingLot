using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLotServiceManager
    {
        public List<ParkingBoy> ManagedParkingBoys { get; } = new List<ParkingBoy>();

        public void AddManagedParkingBoy(ParkingBoy parkingBoy)
        {
            if (parkingBoy != null)
            {
                ManagedParkingBoys.Add(parkingBoy);
            }
        }

        public Ticket ParkByManagedParkingBoy(ParkingBoy parkingBoy, Car car)
        {
            return ManagedParkingBoys.Contains(parkingBoy) ? parkingBoy.Park(car) : null;
        }
    }
}