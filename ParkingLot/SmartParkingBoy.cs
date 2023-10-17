using ParkingLot.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    public class SmartParkingBoy
    {
        private List<ParkingLot> parkingLots;

        public SmartParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = parkingLots;
        }

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new NoTicketProvidedException();
            }

            ParkingLot parkingLotForTicket = parkingLots.Find(parkinglot => parkinglot.HasTicket(ticket));
            if (parkingLotForTicket == null)
            {
                throw new UnrecognizedParkingTicketException();
            }

            return parkingLotForTicket.Fetch(ticket);
        }

        public Ticket Park(Car car)
        {
            ParkingLot parkingLotHasMostPositionLeft = parkingLots
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
