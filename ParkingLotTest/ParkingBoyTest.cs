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

        [Fact]
        public void Should_not_able_to_fetch_car_with_null_ticket()
        {
            ParkingBoy boy = new ParkingBoy();

            NullTicketException e = Assert.Throws<NullTicketException>(() => boy.Fetch(null));
            Assert.Equal("Please provide your parking ticket", e.Message);
        }

        [Fact]
        public void Should_get_null_with_a_wrong_ticket()
        {
            ParkingBoy boy = new ParkingBoy();

            InvalidTicketException e = Assert.Throws<InvalidTicketException>(() => boy.Fetch("wrong ticket"));
            Assert.Equal("Unrecognized parking ticket", e.Message);
        }

        [Fact]
        public void Should_get_exception_with_a_used_ticket()
        {
            ParkingBoy boy = new ParkingBoy();
            const string Car1 = "car1";
            string ticket1 = boy.Park(Car1);

            boy.Fetch(ticket1);
            InvalidTicketException e = Assert.Throws<InvalidTicketException>(() => boy.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket", e.Message);
        }

        [Fact]
        public void Should_not_fetch_ticket_when_reach_the_capacity()
        {
            ParkingBoy boy = new ParkingBoy();
            for (int i = 0; i < boy.GetCapacity(); i++)
            {
                Assert.NotNull(boy.Park($"car{i}"));
            }

            InsufficientPositionException e = Assert.Throws<InsufficientPositionException>(() => boy.Park("car2"));
            Assert.Equal("Not enough position", e.Message);
        }

        [Fact]
        public void Should_get_same_ticket_when_park_the_same_car()
        {
            ParkingBoy boy = new ParkingBoy();
            const string Car1 = "car1";
            string ticket = boy.Park(Car1);

            string doubleTicket = boy.Park(Car1);

            Assert.Equal(ticket, doubleTicket);
        }

        [Fact]
        public void Should_get_null_with_null_car_when_park()
        {
            ParkingBoy boy = new ParkingBoy();

            string nullTicket = boy.Park(null);

            Assert.Null(nullTicket);
        }
    }
}
