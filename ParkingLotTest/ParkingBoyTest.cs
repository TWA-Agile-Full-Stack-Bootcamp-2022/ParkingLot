namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_park_given_a_car()
        {
            // Given
            Car givenCar = new Car();
            var parkingLot = new Mock<ParkingLot>();
            parkingLot.Setup(parkingLot => parkingLot.Park(givenCar)).Returns(new Ticket());
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot.Object);

            // When
            Ticket ticket = parkingBoy.Park(givenCar);
            // Then
            Assert.NotNull(ticket);
            parkingLot.Verify(parkingLot => parkingLot.Park(givenCar), Times.Once());
        }

        [Fact]
        public void Should_return_the_right_car_when_fetch_by_given_ticket()
        {
            // Given
            var parkingLot = new Mock<ParkingLot>();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot.Object);

            Ticket givenTicket = new Ticket();
            Car givenCar = new Car();
            parkingLot.Setup(parkingLot => parkingLot.Fetch(givenTicket)).Returns(givenCar);
            // When
            Car fetchedCar = parkingBoy.Fetch(givenTicket);
            // Then
            Assert.Equal(givenCar, fetchedCar);
            parkingLot.Verify(parkingLot => parkingLot.Fetch(givenTicket), Times.Once());
        }
    }
}
