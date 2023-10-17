namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingBoy
    {
        public List<ParkingLot> ParkingLots { get; set; }
        public IParkingStrategy ParkingStrategy { get; set; } = new StandardParkingStrategy();

        public ParkingTicket ParkCar(Car car) => ParkingStrategy.Which(ParkingLots).ParkCar(car);

        // TODO: need a unit test to verify if the parking boy could fetch the car from the one that the car parked in when the parking boy has multiple parking lots
        public Car FetchCar(ParkingTicket ticket)
        {
            if (ticket == null)
            {
                throw new InvalidOperationException("Please provide your parking ticket.");
            }

            return WhichParkingLotCarParkedIn(ticket.LicensePlate)?.FetchCar(ticket)
                ?? throw new InvalidOperationException("Unrecognized parking ticket.");
        }

        public ParkingLot WhichParkingLotCarParkedIn(string licensePlate) =>
            // NOTE: Determines whether the List(T) contains elements that match the conditions defined by the specified predicate.
            ParkingLots.FirstOrDefault(parkingLot => parkingLot.ParkedCars.Exists(car => car.LicensePlate == licensePlate));
    }
}
