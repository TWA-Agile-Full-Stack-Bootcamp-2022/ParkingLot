using System.Linq;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        public override ParkingLot FindParkingLot()
        {
            return GetParkingLots().Select(parkingLot => parkingLot).OrderByDescending(parkingLot => ((float)parkingLot.LeftPosition) / ((float)parkingLot.Capacity)).FirstOrDefault();
        }
    }
}