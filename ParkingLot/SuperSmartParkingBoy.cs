using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SuperSmartParkingBoy : ParkingBoy
    {
        public SuperSmartParkingBoy(List<Lot> lots) : base(lots)
        {
        }

        public new Ticket Parking(Car car)
        {
            var lot = lots.OrderByDescending(lot => lot.GetVacancyRate()).First();
            if (lot.HasPosition(1))
            {
                return lot.ParkingCar(car);
            }

            throw new LotFullException("Not enough positions.");
        }
    }
}