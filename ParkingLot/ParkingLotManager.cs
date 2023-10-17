using ParkingLot.Exceptions;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkingLotManager
    {
        private readonly List<ParkingBoy> parkingBoys = new List<ParkingBoy>();

        public ParkingLotManager()
        {
        }

        public ParkingLotManager(List<ParkingLot> parkingLots)
        {
            ManagedParkingLots = parkingLots;
        }

        public ParkingLotManager(List<ParkingBoy> parkingBoys)
        {
            this.parkingBoys = parkingBoys;
        }

        public List<ParkingLot> ManagedParkingLots { get; private set; }

        public Car Fetch(Ticket givenTicket)
        {
            ParkingBoy parkingBoyWhoManagedTicket = parkingBoys.Find(parkingboy => parkingboy.HasTicketInManagedParkingLots(givenTicket));
            if (parkingBoyWhoManagedTicket == null)
            {
                // Needs to clarify requirements: no Available parking boy ?
                return FetchBySelf(givenTicket);
            }

            return parkingBoyWhoManagedTicket.Fetch(givenTicket);
        }

        public Ticket Park(Car car)
        {
            ParkingBoy parkingBoy = FindAvailableParkingBoy();
            if (parkingBoy == null)
            {
                return ParkBySelf(car);
            }
            else
            {
               return parkingBoy.Park(car);
            }
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

        private Ticket ParkBySelf(Car car)
        {
            // Duplicate Code
            ParkingLot availableParkingLot = ManagedParkingLots.Find(parkingLot => !parkingLot.IsFull());
            if (availableParkingLot == null)
            {
                throw new NotEnoughPositionException();
            }

            return availableParkingLot.Park(car);
        }

        private Car FetchBySelf(Ticket ticket)
        {
            // Duplicate Code
            if (ticket == null)
            {
                throw new NoTicketProvidedException();
            }

            ParkingLot parkingLotForTicket = ManagedParkingLots.Find(parkinglot => parkinglot.HasTicket(ticket));
            if (parkingLotForTicket == null)
            {
                throw new UnrecognizedParkingTicketException();
            }

            return parkingLotForTicket.Fetch(ticket);
        }
    }
}
