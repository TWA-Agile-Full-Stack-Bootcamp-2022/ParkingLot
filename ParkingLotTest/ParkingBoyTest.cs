namespace ParkingLotTest
{
    using ParkingLot;
    using System.Reflection;
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

        [Fact]
        public void Should_fetch_the_matched_car_with_corresponding_ticket()
        {
            ParkingBoy boy = new ParkingBoy();
            const string Car1 = "Car1";
            string ticket1 = boy.Park(Car1);
            const string Car2 = "Car2";
            string ticket2 = boy.Park(Car2);

            string car1 = boy.Fetch(ticket1);
            string car2 = boy.Fetch(ticket2);

            Assert.Equal(Car1, car1);
            Assert.Equal(Car2, car2);
        }
    }
}
