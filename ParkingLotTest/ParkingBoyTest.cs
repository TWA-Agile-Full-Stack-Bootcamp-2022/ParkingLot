namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using ParkingLot.Exceptions;
    using System.Collections.Generic;
    using System;
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

        [Fact]
        public void Should_return_ticket_when_park_given_a_car_and_first_parkinglot_not_full()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_return_ticket_when_park_given_a_car_and_first_parkinglog_is_full()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_return_NotEnoughPositionException_when_park_given_a_car_and_all_parkinglog_are_full()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_recive_different_tickets_when_park_given_multiple_cars()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_return_the_right_car_when_fetch_by_given_ticket_in_first_parking_lot()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_return_the_right_car_when_fetch_by_given_ticket_in_sequentially_parking_lot()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_fetch_the_right_car_when_fetch_given_multiple_cars()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_throw_UnrecognizedParkingTicketException_when_fetch_by_given_not_existed_ticket()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_throw_UnrecognizedParkingTicketException_when_fetch_given_a_used_ticket()
        {
            // Given
            // When
            // Then
        }

        [Fact]
        public void Should_throw_NoTicketProvidedException_when_fetch_without_ticket()
        {
            // Given
            // When
            // Then
        }
    }
}
