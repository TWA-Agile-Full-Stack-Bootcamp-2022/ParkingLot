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
    }
}