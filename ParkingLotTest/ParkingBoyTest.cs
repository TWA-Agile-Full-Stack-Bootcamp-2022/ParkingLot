namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_fetch_the_same_car_after_parked()
        {
            var boy = new ParkingBoy();
            const string Car1 = "car1";
            string ticket1 = boy.Park(Car1);
            string car1 = boy.Fetch(ticket1);
            Assert.Equal(Car1, car1);
        }
    }
}
