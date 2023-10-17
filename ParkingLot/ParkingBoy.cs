namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingBoy
    {
        public List<ParkingLot> ParkingLots { get; set; }

        public ParkingTicket ParkCar(Car car) => ParkingLots.First().ParkCar(car);

        public Car FetchCar(ParkingTicket ticket) => ParkingLots.First().FetchCar(ticket);
    }
}
