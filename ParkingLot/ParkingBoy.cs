using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly ParkingLot parkingLot = new ParkingLot();
        private List<ParkingLot> parkingLots = new List<ParkingLot>();

        public ParkingBoy()
        {
            parkingLots.Add(new ParkingLot());
            parkingLots.Add(new ParkingLot());
        }

        public string Park(string car)
        {
            return parkingLot.Park(car);
        }

        public string Fetch(string ticket)
        {
            return parkingLot.Fetch(ticket);
        }
    }
}
