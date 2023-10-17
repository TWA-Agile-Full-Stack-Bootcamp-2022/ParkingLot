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

        public Car FetchCar(ParkingTicket ticket) => ParkingStrategy.Which(ParkingLots).FetchCar(ticket);
    }
}
