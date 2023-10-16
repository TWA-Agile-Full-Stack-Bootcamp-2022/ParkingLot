namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_park_given_a_car()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            Car car = new Car();
            // When
            Ticket ticketRecived = parkingLot.Park(car);
            // Then
            Assert.NotNull(ticketRecived);
        }
    }
}
