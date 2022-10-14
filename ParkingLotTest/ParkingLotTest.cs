using Xunit;
using ParkingLot;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_a_ticket_with_TicketNo_when_park_a_car_into_the_parking_lot()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");

            var ticket = parkingLot.Park(car);

            Assert.NotEmpty(ticket.TicketNo);
        }

        [Fact]
        public void Should_parking_capacity_minus_one_when_park_a_car_into_the_parking_lot()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");

            var ticket = parkingLot.Park(car);

            Assert.Equal(0, parkingLot.Capacity);
        }

        [Fact]
        public void Should_pickup_a_car_successfully_when_pickup_given_an_available_ticket()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");
            var ticket = parkingLot.Park(car);

            var pickedCar = parkingLot.Pickup(ticket);

            Assert.Equal("江AB1234", pickedCar.PlateNumber);
        }
    }
}