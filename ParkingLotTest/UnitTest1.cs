namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;
    using System;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var class1 = new Class1();
            Assert.NotNull(class1);
        }

        [Fact]
        public void Should_get_a_ticket_when_given_a_car_to_parking_boy()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);

            var ticket = parkingBoy.Park(car);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_get_right_car_when_given_a_ticket_to_parking_boy()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);
            var ticket = parkingBoy.Park(car);

            var pickUpCar = parkingBoy.PickUp(ticket);

            Assert.Equal(car, pickUpCar);
        }

        [Fact]
        public void Should_get_Exception_when_given_a_wrong_ticket_to_parking_boy()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);

            var ticket = new Ticket();
            var exception = Assert.Throws<Exception>(() => parkingBoy.PickUp(ticket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_get_Exception_when_given_ticket_has_already_used()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);
            var ticket = parkingBoy.Park(car);

            parkingBoy.PickUp(ticket);
            var exception = Assert.Throws<Exception>(() => parkingBoy.PickUp(ticket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_get_no_enough_position_Exception_when_parking_lot_is_full()
        {
            var parkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddParkingLot(parkingLot);
            parkingBoy.Park(new Car());

            var exception = Assert.Throws<Exception>(() => parkingBoy.Park(new Car()));
            Assert.Equal("Not enough position.", exception.Message);
        }

        [Fact]
        public void Should_get_car_is_parked_Exception_when_parking_a_parked_car()
        {
            var car = new Car();
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);
            parkingBoy.Park(car);

            var exception = Assert.Throws<Exception>(() => parkingBoy.Park(car));
            Assert.Equal("Car is parked.", exception.Message);
        }

        [Fact]
        public void Should_get_car_is_null_Exception_when_parking_null_car()
        {
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);

            var exception = Assert.Throws<Exception>(() => parkingBoy.Park(null));
            Assert.Equal("Car is null.", exception.Message);
        }

        [Fact]
        public void Should_get_Exception_when_given_a_null_ticket()
        {
            var parkingBoy = new ParkingBoy();
            var parkingLot = new ParkingLot();
            parkingBoy.AddParkingLot(parkingLot);

            var exception = Assert.Throws<Exception>(() => parkingBoy.PickUp(null));
            Assert.Equal("Please provide your parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_parking_car_to_next_parkingLot_when_first_parkingLot_is_full()
        {
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new ParkingLot();
            var parkingBoy = new ParkingBoy();
            parkingBoy.AddParkingLot(parkingLot1);
            parkingBoy.AddParkingLot(parkingLot2);
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            var car = parkingLot2.PickUp(ticket2);

            Assert.Equal(car2, car);
        }
    }
}
