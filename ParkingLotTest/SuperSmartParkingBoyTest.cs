using Moq;
using ParkingLot.Exceptions;
using System.Collections.Generic;
using System;
using Xunit;

namespace ParkingLotTest
{
    using ParkingLot;
    public class SuperSmartParkingBoyTest
    {
        [Fact]
        public void Should_parking_to_larger_available_position_rate_parkinglot_when_park_given_two_different_parkinglots()
        {
            // Given
            ParkingLot emptyParkingLot = new ParkingLot();

            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            ticketCarPairs.Add(new Ticket(), new Car());
            ParkingLot notEmptyParkingLot = new ParkingLot(ticketCarPairs);

            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { notEmptyParkingLot, emptyParkingLot });
            Car givenCar = new Car();
            // When
            var recivedTicket = smartParkingBoy.Park(givenCar);
            // Then
            Assert.True(emptyParkingLot.HasTicket(recivedTicket));
        }

        [Fact]
        public void Should_throw_NotEnoughPositionException_when_park_given_all_parkinglots_are_full()
        {
            // Given
            Mock<ParkingLot> parkingLot = new Mock<ParkingLot>();
            Mock<ParkingLot> otherParkingLot = new Mock<ParkingLot>();
            parkingLot.Setup(parkingLot => parkingLot.IsFull()).Returns(true);
            otherParkingLot.Setup(parkingLot => parkingLot.IsFull()).Returns(true);

            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { parkingLot.Object, otherParkingLot.Object });
            // When
            Action action = () => smartParkingBoy.Park(new Car());
            // Then
            Exception exception = Assert.Throws<NotEnoughPositionException>(action);
            Assert.Equal("Not enough position.", exception.Message);
        }
    }
}
