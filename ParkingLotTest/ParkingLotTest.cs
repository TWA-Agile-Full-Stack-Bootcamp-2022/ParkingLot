using Xunit;
using ParkingLot;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_a_ticket_with_TicketNo_when_park_a_vehicle_into_the_parking_lot()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");

            var ticket = parkingLot.Park(car);

            Assert.NotEmpty(ticket.TicketNo);
        }
    }
}