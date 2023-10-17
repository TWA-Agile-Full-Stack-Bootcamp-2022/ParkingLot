using System.Collections.Generic;
using Xunit;

namespace ParkingLotTest
{
    using ParkingLot;

    public class ParkingLotManagerTest
    {
        [Fact]
        public void Should_can_park_by_some_type_of_parking_boy_when_manager_park_given_a_some_of_parking_boy()
        {
            // Needs to clarify requirements: How to specify a parking boy ?
            // Given
            List<ParkingLot> parkingLotsOfParkingBoy = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            List<ParkingLot> parkingLotsOfSmartParkingBoy = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            List<ParkingLot> parkingLotsOfSuperParkingBoy = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLotsOfParkingBoy);
            ParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLotsOfSmartParkingBoy);
            ParkingBoy superParkingBoy = new SuperSmartParkingBoy(parkingLotsOfSuperParkingBoy);

            ParkingLotManager parkingLotManager = new ParkingLotManager(new List<ParkingBoy> { parkingBoy, smartParkingBoy, superParkingBoy });
            Car car = new Car();
            // When
            Ticket ticket = parkingLotManager.Park(car);
            // Then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_the_car_when_fetch_given_a_some_of_parking_boy()
        {
            // Needs to clarify requirements: How to specify a parking boy ?
            // Given
            Car givenCar = new Car();
            Ticket givenTicket = new Ticket();
            Dictionary<Ticket, Car> ticketCarPairs = new Dictionary<Ticket, Car>
            {
                { givenTicket, givenCar },
            };

            List<ParkingLot> parkingLotsOfParkingBoy = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            List<ParkingLot> parkingLotsOfSmartParkingBoy = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            List<ParkingLot> parkingLotsOfSuperParkingBoy = new List<ParkingLot> { new ParkingLot(), new ParkingLot(ticketCarPairs) };
            ParkingBoy parkingBoy = new ParkingBoy(parkingLotsOfParkingBoy);
            ParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLotsOfSmartParkingBoy);
            ParkingBoy superParkingBoy = new SuperSmartParkingBoy(parkingLotsOfSuperParkingBoy);

            ParkingLotManager parkingLotManager = new ParkingLotManager(new List<ParkingBoy> { parkingBoy, smartParkingBoy, superParkingBoy });

            // When
            Car fetchedCar = parkingLotManager.Fetch(givenTicket);
            // Then
            Assert.NotNull(fetchedCar);
            Assert.Equal(givenCar, fetchedCar);
        }
    }
}
