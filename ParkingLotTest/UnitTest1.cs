namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var class1 = new Class1();
            Assert.NotNull(class1);
        }

        [Fact]
        public void Should_return_ticket_when_parking_boy_parking_car_given_a_car_and_parking_boy()
        {
            //given
            var car = new Car();
            var parkingLot = new Lot();
            var parkingBoy = new ParkingBoy(parkingLot);
            //when
            var ticket = parkingBoy.Parking(car);
            //then
            Assert.Equal(car, ticket.GetCar());
        }

        [Fact]
        public void Should_can_get_back_car_when_pick_up_car_given_ticket_and_parking_boy()
        {
            //given
            var car = new Car();
            var parkingLot = new Lot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var ticket = parkingBoy.Parking(car);
            //when
            Car pickUpCar = parkingBoy.PickUp(ticket);
            //then
            Assert.Equal(car, pickUpCar);
        }
    }
}
