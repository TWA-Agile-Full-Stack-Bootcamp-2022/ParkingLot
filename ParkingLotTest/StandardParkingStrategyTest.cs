namespace ParkingLotTest
{
    using System.Collections.Generic;
    using Moq;
    using ParkingLot;
    using Xunit;

    public class StandardParkingStrategyTest
    {
        [Fact]
        public void Park_cars_to_the_second_parking_lot_when_the_first_parking_lot_is_full()
        {
            // given
            // NOTE: mock class
            var parkingLot1 = new Mock<ParkingLot>();
            parkingLot1.Setup(p => p.IsFull).Returns(true);
            var parkingLot2 = new Mock<ParkingLot>();
            IParkingStrategy strategy = new StandardParkingStrategy();

            // when
            var parkingLot = strategy.Which(new List<ParkingLot> { parkingLot1.Object, parkingLot2.Object });

            // then
            Assert.Equal(parkingLot2.Object, parkingLot);
        }
    }
}
