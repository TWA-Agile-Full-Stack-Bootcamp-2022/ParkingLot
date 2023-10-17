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
            int firstParkingLotCapacity = 2;
            int secondParkingLotCapacity = 3;
            ParkingLot firstParkingLot = new ParkingLot(firstParkingLotCapacity);

            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>();
            ticketCarPairs.Add(new Ticket(), new Car());
            ParkingLot secondeParkingLot = new ParkingLot(ticketCarPairs, secondParkingLotCapacity);

            var superSmartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { firstParkingLot, secondeParkingLot });
            Car givenCar = new Car();

            // When
            var recivedTicket = superSmartParkingBoy.Park(givenCar);

            // Then
            Assert.True(firstParkingLot.HasTicket(recivedTicket));
            Assert.Equal(0.5, firstParkingLot.GetAvailablePositionRate());
            Assert.Equal(0.67, Math.Round(secondeParkingLot.GetAvailablePositionRate(), 2));
        }

        [Fact]
        public void Should_throw_NotEnoughPositionException_when_park_given_all_parkinglots_are_full()
        {
            // Given
            Mock<ParkingLot> parkingLot = new Mock<ParkingLot>();
            Mock<ParkingLot> otherParkingLot = new Mock<ParkingLot>();
            parkingLot.Setup(parkingLot => parkingLot.IsFull()).Returns(true);
            otherParkingLot.Setup(parkingLot => parkingLot.IsFull()).Returns(true);

            SuperSmartParkingBoy smartParkingBoy = new SuperSmartParkingBoy(new List<ParkingLot> { parkingLot.Object, otherParkingLot.Object });
            // When
            Action action = () => smartParkingBoy.Park(new Car());
            // Then
            Exception exception = Assert.Throws<NotEnoughPositionException>(action);
            Assert.Equal("Not enough position.", exception.Message);
        }
    }
}
