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
    }
}
