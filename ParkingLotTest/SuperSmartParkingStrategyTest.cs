namespace ParkingLotTest
{
    using System.Collections.Generic;
    using Moq;
    using ParkingLot;
    using Xunit;

    public class SuperSmartParkingStrategyTest
    {
        [Fact]
        public void Park_cars_to_parking_lot_which_has_a_larger_available_position_rate()
        {
            // given
            // NOTE: mock class
            var parkingLot1 = new Mock<ParkingLot>();
            parkingLot1.Setup(p => p.NumOfEmptyPositions).Returns(5);
            var parkingLot2 = new Mock<ParkingLot>();
            parkingLot2.Setup(p => p.NumOfEmptyPositions).Returns(10);
            IParkingStrategy strategy = new SuperSmartParkingStrategy();

            // when
            var parkingLot = strategy.Which(new List<ParkingLot> { parkingLot1.Object, parkingLot2.Object });

            // then
            Assert.Equal(parkingLot2.Object, parkingLot);
        }
    }
}
