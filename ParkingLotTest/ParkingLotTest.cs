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

        [Fact]
        public void Should_recive_different_tickets_when_park_given_multiple_cars()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            Car car = new Car();
            Car otherCar = new Car();
            // When
            Ticket ticketRecived = parkingLot.Park(car);
            Ticket ticketRecivedOther = parkingLot.Park(otherCar);
            // Then
            Assert.NotNull(ticketRecived);
            Assert.NotNull(ticketRecivedOther);
            Assert.NotEqual(ticketRecived, ticketRecivedOther);
        }

        [Fact]
        public void Should_fetch_the_right_car_when_fetch_given_multiple_cars()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();

            Car givenCar = new Car();
            Car givenOtherCar = new Car();
            Ticket givenTicket = new Ticket();
            Ticket givenOtherTicket = new Ticket();

            ticketCarPairs.Add(givenTicket, givenCar);
            ticketCarPairs.Add(givenOtherTicket, givenOtherCar);

            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);

            // When
            Car fetchedCar = parkingLot.Fetch(givenTicket);
            Car fetchedOtherCar = parkingLot.Fetch(givenOtherTicket);
            // Then
            Assert.Equal(givenCar, fetchedCar);
            Assert.Equal(givenOtherCar, fetchedOtherCar);
        }
    }
}
