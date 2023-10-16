namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
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

        [Fact]
        public void Should_return_the_right_car_when_fetch_by_given_ticket()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            Ticket givenTicket = new Ticket();
            Car givenCar = new Car();
            ticketCarPairs.Add(givenTicket, givenCar);
            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);

            // When
            Car fetchedCar = parkingLot.Fetch(givenTicket);
            // Then
            Assert.Equal(givenCar, fetchedCar);
        }
    }
}
