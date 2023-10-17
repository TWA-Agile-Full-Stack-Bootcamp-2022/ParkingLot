using ParkingLot.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public override Ticket Park(Car car)
        {
            ParkingLot parkingLotHasMostPositionLeft = ParkingLots
                .OrderByDescending(parkingLot => parkingLot.GetPositionLeft())
                .First();

            if (parkingLotHasMostPositionLeft.IsFull())
            {
                throw new NotEnoughPositionException();
            }

            return parkingLotHasMostPositionLeft.Park(car);
        }
    }
}
