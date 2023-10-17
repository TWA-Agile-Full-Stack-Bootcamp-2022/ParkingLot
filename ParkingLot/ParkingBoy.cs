namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingBoy
    {
        public ParkingLot ParkingLot { get; set; }

        public ParkingTicket ParkCar(Car car) => ParkingLot.ParkCar(car);

        public Car FetchCar(ParkingTicket ticket) => ParkingLot.FetchCar(ticket);
    }
}
