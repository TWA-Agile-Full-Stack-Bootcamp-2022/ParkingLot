using Xunit;
using ParkingLot;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_a_ticket_with_TicketNo_when_park_a_car_into_the_parking_lot()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");

            var ticket = parkingLot.Park(car);

            Assert.NotEmpty(ticket.TicketNo);
        }

        [Fact]
        public void Should_parking_capacity_minus_one_when_park_a_car_into_the_parking_lot()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");

            var ticket = parkingLot.Park(car);

            Assert.Equal(0, parkingLot.Capacity);
        }

        [Fact]
        public void Should_fetch_a_car_successfully_when_fetch_given_an_available_ticket()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");
            var ticket = parkingLot.Park(car);

            var fetchedCar = parkingLot.Fetch(ticket);

            Assert.Equal("江AB1234", fetchedCar.PlateNumber);
        }

        [Fact]
        public void Should_parking_capacity_plus_one_when_fetch_a_car_from_the_parking_lot()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");
            var ticket = parkingLot.Park(car);

            parkingLot.Fetch(ticket);

            Assert.Equal(1, parkingLot.Capacity);
        }

        [Fact]
        public void Should_fetch_the_correct_car_when_fetch_given_multiple_cars_in_parking_lot()
        {
            var parkingLot = new ParkingLot.ParkingLot(2);
            var carFirst = new Car("江AAAAA");
            var carSecond = new Car("江BBBBB");
            var ticketForCarFirst = parkingLot.Park(carFirst);
            parkingLot.Park(carSecond);

            var fetchedCar = parkingLot.Fetch(ticketForCarFirst);

            Assert.Equal(carFirst, fetchedCar);
        }

        [Fact]
        public void Should_throw_IllegalTicketException_when_fetch_given_wrong_ticket()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");
            parkingLot.Park(car);

            void FetchWithWrongTicket() => parkingLot.Fetch(new Ticket());

            Assert.Throws<IllegalTicketException>(FetchWithWrongTicket);
        }

        [Fact]
        public void Should_throw_IllegalTicketException_when_fetch_given_used_ticket()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");
            var ticket = parkingLot.Park(car);
            parkingLot.Fetch(ticket);

            void FetchCarWithUsedTicket() => parkingLot.Fetch(ticket);

            var illegalTicketException = Assert.Throws<IllegalTicketException>(FetchCarWithUsedTicket);
            Assert.Equal("Unrecognized parking ticket.", illegalTicketException.Message);
        }

        [Fact]
        public void Should_throw_IllegalTicketException_when_fetch_given_no_ticket()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car = new Car("江AB1234");
            parkingLot.Park(car);

            void FetchCarWithoutTicket() => parkingLot.Fetch(null);

            var illegalTicketException = Assert.Throws<IllegalTicketException>(FetchCarWithoutTicket);
            Assert.Equal("Please provide your parking ticket.", illegalTicketException.Message);
        }

        [Fact]
        public void Should_throw_NoAvailablePositionException_when_parking_given_no_available_position_left()
        {
            var parkingLot = new ParkingLot.ParkingLot(1);
            parkingLot.Park(new Car("江AB1234"));

            void ParkingNewCarWithNoAvailablePosition() => parkingLot.Park(new Car("江BBBBBB"));

            var noAvailablePositionException =
                Assert.Throws<NoAvailablePositionException>(ParkingNewCarWithNoAvailablePosition);
            Assert.Equal("Not enough position.", noAvailablePositionException.Message);
        }

        [Fact]
        public void Should_throw_DuplicateCarException_when_parking_given_duplicate_car()
        {
            var parkingLot = new ParkingLot.ParkingLot(2);
            parkingLot.Park(new Car("江AB1234"));

            void ParkingDuplicateCar() => parkingLot.Park(new Car("江AB1234"));

            Assert.Throws<DuplicateCarException>(ParkingDuplicateCar);
        }
    }
}