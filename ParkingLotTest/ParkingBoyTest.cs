using System.Collections;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_park_to_the_first_parking_lot_given_parking_boy_manage_2_parking_lot_and_both_empty()
        {
            var firstParkingLot = new ParkingLot.ParkingLot(1);
            var secondParkingLot = new ParkingLot.ParkingLot(2);
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddManagedParkingLot(firstParkingLot);
            parkingBoy.AddManagedParkingLot(secondParkingLot);

            var ticket = parkingBoy.Park(new Car("江AB1234"));

            Assert.NotEmpty(ticket.TicketNo);
            Assert.Equal(0, firstParkingLot.Capacity);
            Assert.Equal(2, secondParkingLot.Capacity);
        }

        [Fact]
        public void Should_park_to_the_second_parking_lot_given_parking_boy_manage_2_parking_lot_and_first_is_full()
        {
            var firstParkingLot = new ParkingLot.ParkingLot(0);
            var secondParkingLot = new ParkingLot.ParkingLot(2);
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddManagedParkingLot(firstParkingLot);
            parkingBoy.AddManagedParkingLot(secondParkingLot);

            var ticket = parkingBoy.Park(new Car("江AB1234"));

            Assert.NotEmpty(ticket.TicketNo);
            Assert.Equal(0, firstParkingLot.Capacity);
            Assert.Equal(1, secondParkingLot.Capacity);
        }
    }
}