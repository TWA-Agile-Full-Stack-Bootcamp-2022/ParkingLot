﻿namespace ParkingLotTest
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
            for (int i = 0; i < ParkingLot.MaxCapacity; i++) 
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
