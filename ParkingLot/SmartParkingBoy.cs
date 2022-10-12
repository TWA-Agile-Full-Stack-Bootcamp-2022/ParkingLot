using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(List<Lot> parkingLots) : base(parkingLots)
        {
        }

        public new Ticket Parking(Car car)
        {
            var maxSpaceLot = lots.OrderByDescending(t => t.GetPosition()).First();
            if (maxSpaceLot.HasPosition(1))
            {
                return maxSpaceLot.ParkingCar(car);
            }

            throw new LotFullException("Not enough positions.");
        }

        public new List<Ticket> Parking(List<Car> cars)
        {
           return cars.Select(Parking).ToList();
        }
    }
}