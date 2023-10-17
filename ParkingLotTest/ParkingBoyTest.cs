namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using ParkingLot.Exceptions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_ticket_when_park_given_a_car_and_first_parkinglot_not_full()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            ParkingLot anotherParkingLot = new ParkingLot();

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            Car car = new Car();
            // When
            Ticket ticketRecived = parkingBoy.Park(car);
            // Then
            Assert.NotNull(ticketRecived);
            Assert.NotNull(parkingLot.Fetch(ticketRecived));
        }

        [Fact]
        public void Should_return_ticket_when_park_given_a_car_and_first_parkinglog_is_full()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            ParkingLot anotherParkingLot = new ParkingLot();

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            for (int i = 0; i < ParkingLot.DefaultCapacity; i++)
            {
                parkingLot.Park(new Car());
            }

            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            Car car = new Car();
            // When
            Ticket ticketRecived = parkingBoy.Park(car);
            // Then
            Assert.NotNull(ticketRecived);
            Assert.NotNull(anotherParkingLot.Fetch(ticketRecived));
        }

        [Fact]
        public void Should_recive_different_tickets_when_park_given_multiple_cars()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            ParkingLot anotherParkingLot = new ParkingLot();

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            Car car = new Car();
            Car anotherCar = new Car();
            // When
            Ticket ticketRecived = parkingBoy.Park(car);
            Ticket anotherTicketRecived = parkingBoy.Park(anotherCar);
            // Then
            Assert.NotNull(ticketRecived);
            Assert.NotNull(anotherTicketRecived);
            Assert.NotEqual(ticketRecived, anotherTicketRecived);
        }

        [Fact]
        public void Should_return_NotEnoughPositionException_when_park_given_a_car_and_all_parkinglog_are_full()
        {
            // Given
            var parkingLot = new Mock<ParkingLot>();
            var anotherParkingLot = new Mock<ParkingLot>();
            parkingLot.Setup(parkinglot => parkinglot.IsFull()).Returns(true);
            anotherParkingLot.Setup(parkinglot => parkinglot.IsFull()).Returns(true);

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot.Object);
            managedParkingLots.Add(anotherParkingLot.Object);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            // When
            Action action = () => parkingBoy.Park(new Car());

            // Then
            Exception exception = Assert.Throws<NotEnoughPositionException>(action);
            Assert.Equal("Not enough position.", exception.Message);
        }

        [Fact]
        public void Should_return_the_right_car_when_fetch_by_given_ticket_in_first_parking_lot()
        {
            // Given
            Car givenCar = new Car();
            Ticket givenTicket = new Ticket();
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            ticketCarPairs.Add(givenTicket, givenCar);
            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);
            ParkingLot anotherParkingLot = new ParkingLot();

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            // When
            Car fetchedCar = parkingBoy.Fetch(givenTicket);
            // Then
            Assert.NotNull(fetchedCar);
            Assert.Equal(givenCar, fetchedCar);
        }

        [Fact]
        public void Should_return_the_right_car_when_fetch_by_given_ticket_in_sequentially_parking_lot()
        {
            // Given
            Car givenCar = new Car();
            Ticket givenTicket = new Ticket();
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            ticketCarPairs.Add(givenTicket, givenCar);
            ParkingLot parkingLot = new ParkingLot();
            ParkingLot anotherParkingLot = new ParkingLot(ticketCarPairs);

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            // When
            Car fetchedCar = parkingBoy.Fetch(givenTicket);
            // Then
            Assert.NotNull(fetchedCar);
            Assert.Equal(givenCar, fetchedCar);
        }

        [Fact]
        public void Should_fetch_the_right_car_when_fetch_given_multiple_cars()
        {
            // Given
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            Car firstCar = new Car();
            Ticket firstTicket = new Ticket();
            ticketCarPairs.Add(firstTicket, firstCar);
            ParkingLot parkingLot = new ParkingLot(ticketCarPairs);

            Dictionary<Ticket, Car> anotherticketCarPairs = new Dictionary<Ticket, Car>();
            Car secondCar = new Car();
            Ticket secondTicket = new Ticket();
            anotherticketCarPairs.Add(secondTicket, secondCar);
            ParkingLot anotherParkingLot = new ParkingLot(anotherticketCarPairs);

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            // When
            Car firstFetchedCar = parkingBoy.Fetch(firstTicket);
            Car secondFetchedCar = parkingBoy.Fetch(secondTicket);
            // Then
            Assert.NotNull(firstFetchedCar);
            Assert.NotNull(secondFetchedCar);
            Assert.Equal(firstCar, firstFetchedCar);
            Assert.Equal(secondCar, secondFetchedCar);
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
            ParkingLot anotherParkingLot = new ParkingLot();

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            // When
            Car theCarFetchedBefore = parkingBoy.Fetch(givenTicket);
            Action action = () => parkingBoy.Fetch(new Ticket());
            // Then
            Assert.NotNull(theCarFetchedBefore);
            Exception exception = Assert.Throws<UnrecognizedParkingTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_UnrecognizedParkingTicketException_when_fetch_given_a_used_ticket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            ParkingLot anotherParkingLot = new ParkingLot();

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            // When
            Action action = () => parkingBoy.Fetch(new Ticket());
            // Then
            Exception exception = Assert.Throws<UnrecognizedParkingTicketException>(action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_NoTicketProvidedException_when_fetch_without_ticket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            ParkingLot anotherParkingLot = new ParkingLot();

            List<ParkingLot> managedParkingLots = new List<ParkingLot>();
            managedParkingLots.Add(parkingLot);
            managedParkingLots.Add(anotherParkingLot);
            ParkingBoy parkingBoy = new ParkingBoy(managedParkingLots);

            // When
            Action action = () => parkingBoy.Fetch(null);
            // Then
            Exception exception = Assert.Throws<NoTicketProvidedException>(action);
            Assert.Equal("Please provide your parking ticket.", exception.Message);
        }
    }
}
