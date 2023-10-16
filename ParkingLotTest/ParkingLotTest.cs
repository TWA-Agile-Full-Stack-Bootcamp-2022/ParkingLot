namespace ParkingLotTest
{
    using ParkingLot;
    using ParkingLot.Exceptions;
    using System;
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

        [Fact]
        public void Should_throw_UnrecognizedParkingTicketException_when_fetch_by_given_not_existed_ticket()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            Car givenCar = new Car();
            Ticket givenTicket = new Ticket();

            ticketCarPairs.Add(givenTicket, givenCar);

            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);

            Ticket worngTicketNOTinParkingLot = new Ticket();
            // When
            Action action = () => parkingLot.Fetch(worngTicketNOTinParkingLot);
            // Then
            Exception exception = Assert.Throws<UnrecognizedParkingTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_UnrecognizedParkingTicketException_when_fetch_given_a_used_ticket()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            Car givenCar = new Car();
            Ticket givenTicket = new Ticket();

            ticketCarPairs.Add(givenTicket, givenCar);

            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);

            // When
            Car fetchedCar = parkingLot.Fetch(givenTicket);
            Action action = () => parkingLot.Fetch(givenTicket);
            // Then
            Exception exception = Assert.Throws<UnrecognizedParkingTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_NoTicketProvidedException_when_fetch_without_ticket()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            Car givenCar = new Car();
            Ticket givenTicket = new Ticket();

            ticketCarPairs.Add(givenTicket, givenCar);

            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);

            // When
            Action action = () => parkingLot.Fetch(null);
            // Then
            Exception exception = Assert.Throws<NoTicketProvidedException>(action);
            Assert.Equal("Please provide your parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_NotEnoughPositionException_when_park_given_a_parkinglot_already_parked_10_cars()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            for (int i = 0; i < ParkingLot.MaxCapacity; i++)
            {
                ticketCarPairs.Add(new Ticket(), new Car());
            }

            // When
            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);
            Action action = () => parkingLot.Park(new Car());
            // Then
            Exception exception = Assert.Throws<NotEnoughPositionException>(action);
            Assert.Equal("Not enough position.", exception.Message);
        }

        [Fact]
        public void Should_return_true_when_verify_isFull_given_no_position_parkinglot()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            for (int i = 0; i < ParkingLot.MaxCapacity; i++)
            {
                ticketCarPairs.Add(new Ticket(), new Car());
            }

            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);
            // When
            bool isFull = parkingLot.IsFull();
            // Then
            Assert.True(isFull);
        }

        [Fact]
        public void Should_return_true_when_verify_isFull_given_a_parkinglot_empty()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);
            // When
            bool isFull = parkingLot.IsFull();
            // Then
            Assert.False(isFull);
        }

        [Fact]
        public void Should_return_true_when_verify_hasTicket_given_the_ticket_in_the_parkinglot()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            Ticket givenTicket = new Ticket();
            Car car = new Car();
            ticketCarPairs.Add(givenTicket, car);

            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);
            // When
            bool hasTicket = parkingLot.HasTicket(givenTicket);
            // Then
            Assert.True(hasTicket);
        }

        [Fact]
        public void Should_return_false_when_verify_hasTicket_given_the_ticket_NOT_in_the_parkinglot()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);
            // When
            bool hasTicket = parkingLot.HasTicket(new Ticket());
            // Then
            Assert.False(hasTicket);
        }
    }
}
