namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Theory]
        [InlineData("1234")]
        public void Parking_boy_can_park_a_car_into_parking_lot_and_returns_a_parking_ticket_which_could_be_used_to_fetch_car(string licensePlate)
        {
            // given
            ParkingBoy parkingBoy = new ParkingBoy { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            Car car = new Car { LicensePlate = licensePlate, };

            // when
            var ticket = parkingBoy.ParkCar(car);

            // then
            Assert.IsType<ParkingTicket>(ticket);
            Assert.Equal(car, parkingBoy.FetchCar(ticket));
        }

        [Theory]
        [InlineData("1234", "5678", "9012")] // NOTE: Use InlineData to pass a list
        public void Parking_boy_can_park_multiple_cars_into_on_parking_lot_and_can_fetch_right_car_using_correspond_ticket(params string[] licensePlates)
        {
            // given
            ParkingBoy parkingBoy = new ParkingBoy { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            var cars = licensePlates.Select(licensePlate => new Car { LicensePlate = licensePlate, });

            // when
            var tickets = cars.Select(parkingBoy.ParkCar);

            // then
            Assert.Equal(cars, tickets.Select(parkingBoy.FetchCar));
        }

        [Theory]
        [InlineData("1234", "2345", "3456", "4567", "5678", "6789", "7890", "8901", "9012", "0123")]
        public void When_parking_boy_attempt_to_park_a_car_into_a_parking_lot_without_a_position_error_message_should_be_not_enough_position(params string[] licensePlates)
        {
            // given
            ParkingBoy parkingBoy = new ParkingBoy { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            var cars = licensePlates.Select(licensePlate => new Car { LicensePlate = licensePlate, });
            Assert.Equal(10, cars.Count());

            // when
            var tickets = cars.Select(parkingBoy.ParkCar);
            Assert.Equal(10, tickets.Count());
            void Action() => parkingBoy.ParkCar(new Car { LicensePlate = "1111", });

            // then
            var exception = Assert.Throws<InvalidOperationException>(Action);
            Assert.Equal("Not enough position.", exception.Message);
        }

        [Theory]
        [InlineData("1234")]
        public void If_customer_does_not_give_a_ticket_then_no_car_should_be_fetched(string licensePlate)
        {
            // given
            ParkingBoy parkingBoy = new ParkingBoy { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            Car car = new Car { LicensePlate = licensePlate, };

            // when
            ParkingTicket ticket = null;
            void Action() => parkingBoy.FetchCar(ticket);

            // then
            var exception = Assert.Throws<InvalidOperationException>(Action);
            Assert.Equal("Please provide your parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("1234")]
        public void If_customer_give_a_unknown_ticket_then_no_car_should_be_fetched(string licensePlate)
        {
            // given
            ParkingBoy parkingBoy = new ParkingBoy { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            Car car = new Car { LicensePlate = licensePlate, };

            // when
            var ticket = parkingBoy.ParkCar(car);
            void Action() => parkingBoy.FetchCar(new ParkingTicket());

            // then
            var exception = Assert.Throws<InvalidOperationException>(Action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Theory]
        [InlineData("1234")]
        public void If_customer_gives_a_ticket_that_has_already_been_used_then_no_car_should_be_fetched(string licensePlate)
        {
             // given
            ParkingBoy parkingBoy = new ParkingBoy { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            Car car = new Car { LicensePlate = licensePlate, };

            // when
            var ticket = parkingBoy.ParkCar(car);
            var car1 = parkingBoy.FetchCar(ticket);
            void Action() => parkingBoy.FetchCar(ticket);

            // then
            var exception = Assert.Throws<InvalidOperationException>(Action);
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }
    }
}
