using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotServiceManagerTest
    {
        [Fact]
        public void Should_add_parking_boy_to_management_list()
        {
            var parkingBoy = new ParkingBoy();
            var parkingLogServiceManager = new ParkingLotServiceManager();

            parkingLogServiceManager.AddManagedParkingBoy(parkingBoy);

            Assert.Single(parkingLogServiceManager.ManagedParkingBoys);
        }

        [Fact]
        public void Should_specify_parking_boy_to_park_car_when_parking_boy_is_on_the_management_list()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddManagedParkingLot(parkingLot);
            var parkingLogServiceManager = new ParkingLotServiceManager();
            parkingLogServiceManager.AddManagedParkingBoy(parkingBoy);

            var ticket = parkingLogServiceManager.ParkByManagedParkingBoy(parkingBoy, new Car("江AB1234"));

            Assert.NotEmpty(ticket.TicketNo);
            Assert.Equal(0, parkingLot.Capacity);
        }

        [Fact]
        public void Should_specify_parking_boy_to_fetch_car_when_parking_boy_is_on_the_management_list()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddManagedParkingLot(parkingLot);
            var parkingLogServiceManager = new ParkingLotServiceManager();
            parkingLogServiceManager.AddManagedParkingBoy(parkingBoy);
            var car = new Car("江AB1234");
            var ticket = parkingLogServiceManager.ParkByManagedParkingBoy(parkingBoy, car);

            var fetchedCar = parkingLogServiceManager.FetchByManagedParkingBoy(parkingBoy, ticket);

            Assert.Equal(car, fetchedCar);
            Assert.Equal(1, parkingLot.Capacity);
        }
    }
}