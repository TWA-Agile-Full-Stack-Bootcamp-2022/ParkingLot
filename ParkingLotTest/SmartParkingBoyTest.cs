using Xunit;

namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_parking_to_has_more_position_parkinglot_when_park_given_two_different_position_left_parkinglots()
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
    }
}