using System;
using System.Collections;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Theory]
        [InlineData(typeof(ParkingBoy))]
        [InlineData(typeof(SmartParkingBoy))]
        [InlineData(typeof(SuperSmartParkingBoy))]
        public void Should_throw_exception_when_park_given_parking_boy_manage_no_parking_lots(Type objectType)
        {
            var parkingBoy = (ParkingBoy)Activator.CreateInstance(objectType);

            void ParkWithoutParkingLotManaged() => parkingBoy.Park(new Car("江AB1234"));

            Assert.Throws<NoParkingLotsManagedException>(ParkWithoutParkingLotManaged);
        }

        [Theory]
        [InlineData(typeof(ParkingBoy))]
        [InlineData(typeof(SmartParkingBoy))]
        [InlineData(typeof(SuperSmartParkingBoy))]
        public void Should_throw_exception_when_fetch_given_parking_boy_manage_no_parking_lots(Type objectType)
        {
            var parkingBoy = (ParkingBoy)Activator.CreateInstance(objectType);

            void ParkWithoutParkingLotManaged() => parkingBoy.Fetch(new Ticket());

            Assert.Throws<NoParkingLotsManagedException>(ParkWithoutParkingLotManaged);
        }

        [Fact]
        public void Should_park_to_the_first_parking_lot_given_parking_boy_manage_2_parking_lot_and_both_empty()
        {
            var firstParkingLot = new ParkingLot.ParkingLot(1);
            var secondParkingLot = new ParkingLot.ParkingLot(2);
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddManagedParkingLot(firstParkingLot);
            parkingBoy.AddManagedParkingLot(secondParkingLot);

            var ticket = parkingBoy.Park(new Car("江AB1234"));

            Assert.NotEmpty(ticket.TicketNo);
            Assert.Equal(0, firstParkingLot.Capacity);
            Assert.Equal(2, secondParkingLot.Capacity);
        }

        [Fact]
        public void Should_park_to_the_second_parking_lot_given_parking_boy_manage_2_parking_lot_and_first_is_full()
        {
            var firstParkingLot = new ParkingLot.ParkingLot(0);
            var secondParkingLot = new ParkingLot.ParkingLot(2);
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddManagedParkingLot(firstParkingLot);
            parkingBoy.AddManagedParkingLot(secondParkingLot);

            var ticket = parkingBoy.Park(new Car("江AB1234"));

            Assert.NotEmpty(ticket.TicketNo);
            Assert.Equal(0, firstParkingLot.Capacity);
            Assert.Equal(1, secondParkingLot.Capacity);
        }

        [Fact]
        public void
            Should_park_to_the_second_parking_lot_given_smart_parking_boy_park_given_the_second_parking_lot_have_more_positions()
        {
            var firstParkingLot = new ParkingLot.ParkingLot(1);
            var secondParkingLot = new ParkingLot.ParkingLot(2);
            var parkingBoy = new SmartParkingBoy();
            parkingBoy.AddManagedParkingLot(firstParkingLot);
            parkingBoy.AddManagedParkingLot(secondParkingLot);

            var ticket = parkingBoy.Park(new Car("江AB1234"));

            Assert.NotEmpty(ticket.TicketNo);
            Assert.Equal(1, firstParkingLot.Capacity);
            Assert.Equal(1, secondParkingLot.Capacity);
        }

        [Fact]
        public void
            Should_park_to_the_second_parking_lot_given_super_smart_parking_boy_park_given_the_second_parking_lot_have_larger_available_position_rate()
        {
            var parkingLotWithAvailableRate80Percent = GivenParkingLot(20, 4);
            var parkingLotWithAvailableRate90Percent = GivenParkingLot(10, 1);
            var parkingBoy = new SuperSmartParkingBoy();
            parkingBoy.AddManagedParkingLot(parkingLotWithAvailableRate80Percent);
            parkingBoy.AddManagedParkingLot(parkingLotWithAvailableRate90Percent);

            var ticket = parkingBoy.Park(new Car("江AB1234"));

            Assert.NotEmpty(ticket.TicketNo);
            Assert.Equal(16, parkingLotWithAvailableRate80Percent.Capacity);
            Assert.Equal(8, parkingLotWithAvailableRate90Percent.Capacity);
        }

        private ParkingLot.ParkingLot GivenParkingLot(int capacity, int parkedCount)
        {
            var parkingLot = new ParkingLot.ParkingLot(capacity);
            for (var i = 0; i < parkedCount; i++)
            {
                parkingLot.Park(new Car($"江A{new Random().Next(10000, 99999)}"));
            }

            return parkingLot;
        }
    }
}