using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var class1 = new Class1();
            Assert.NotNull(class1);
        }

        [Fact]
        public void Should_return_ticket_when_parking_boy_parking_car_given_a_car_and_parking_boy()
        {
            //given
            var car = new Car();
            var parkingLot = new Lot();
            var parkingBoy = new ParkingBoy(parkingLot);
            //when
            var ticket = parkingBoy.Parking(car);
            //then
            Assert.Equal(car, ticket.GetCar());
        }

        [Fact]
        public void Should_can_get_back_car_when_pick_up_car_given_ticket_and_parking_boy()
        {
            //given
            var car = new Car();
            var parkingLot = new Lot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var ticket = parkingBoy.Parking(car);
            //when
            var pickUpCar = parkingBoy.PickUp(ticket);
            //then
            Assert.Equal(car, pickUpCar);
        }

        [Fact]
        public void Should_return_tickets_when_batch_parking_car_given_parking_boy_and_cars()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            var cars = new List<Car>
            {
                car1,
                car2,
                car3,
            };
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
            //when
            var tickets = parkingBoy.Parking(cars);
            //then
            Assert.Equal(car1, tickets[0].GetCar());
            Assert.Equal(car2, tickets[1].GetCar());
            Assert.Equal(car3, tickets[2].GetCar());
        }

        [Fact]
        public void Should_can_pick_up_use_batch_parking_ticket()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            var cars = new List<Car>
            {
                car1,
                car2,
                car3,
            };
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
            var tickets = parkingBoy.Parking(cars);
            //then
            Assert.Equal(car1, parkingBoy.PickUp(tickets[0]));
            Assert.Equal(car2, parkingBoy.PickUp(tickets[1]));
            Assert.Equal(car3, parkingBoy.PickUp(tickets[2]));
        }

        [Fact]
        public void Should_return_null_when_given_null_as_ticket()
        {
            //given
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
            //when
            var pickUp = parkingBoy.PickUp(null);
            //then
            Assert.Null(pickUp);
        }

        [Fact]
        public void Should_return_null_when_given_ticket_not_in_lot()
        {
            //given
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
           //when
            var pickUp = parkingBoy.PickUp(new Ticket(null));
           //then
            Assert.Null(pickUp);
        }

        [Fact]
        public void Should_return_null_when_ticket_is_used()
        {
           //given
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
            var car = new Car();
            var ticket = parkingBoy.Parking(car);
            parkingBoy.PickUp(ticket);
            //when
            var pickUp = parkingBoy.PickUp(ticket);
            //then
            Assert.Null(pickUp);
        }

        [Fact]
        public void Should_can_not_parking_when_lot_is_full()
        {
            //given
            var paringLot = new Lot(2);
            var parkingBoy = new ParkingBoy(paringLot);
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            parkingBoy.Parking(car1);
            parkingBoy.Parking(car2);
            //when
            var ticket = parkingBoy.Parking(car3);
            //then
            Assert.Null(ticket);
        }

        [Fact]
        public void Should_can_not_batch_parking_when_lot_is_full()
        {
            //given
            var paringLot = new Lot(2);
            var parkingBoy = new ParkingBoy(paringLot);
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            parkingBoy.Parking(car1);
            //when
            var tickets = parkingBoy.Parking(new List<Car> { car2, car3 });
            //then
            Assert.Empty(tickets);
        }
    }
}