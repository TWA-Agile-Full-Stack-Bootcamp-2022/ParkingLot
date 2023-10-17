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
        public void Should_get_a_ticket_when_given_a_car_to_parking_boy()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);

            var ticket = parkingBoy.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_get_right_car_when_given_a_ticket_to_parking_boy()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);
            var ticket = parkingBoy.Park(car);

            var pickUpCar = parkingBoy.PickUp(ticket);

            Assert.Equal(car, pickUpCar);
        }
    }
}
