using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingManager : ParkingBoy
    {
        private List<ParkingBoy> boys;
        public ParkingManager(List<Lot> list, List<ParkingBoy> parkingBoys) : base(list)
        {
            boys = parkingBoys;
        }

        public Ticket ParkingByBoy(Car car)
        {
            Exception lastException = null;
            foreach (var t in boys)
            {
                try
                {
                    return t.Parking(car);
                }
                catch (Exception e)
                {
                    lastException = e;
                    throw;
                }
            }

            throw lastException;
        }
    }
}