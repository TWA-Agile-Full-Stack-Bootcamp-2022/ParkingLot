using System.Linq;
namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public override ParkingLot FindParkingLot()
        {
            return this.GetParkingLots().Select(parkingLot => parkingLot).OrderByDescending(parkingLot => parkingLot.LeftPosition).FirstOrDefault();
        }
    }
}