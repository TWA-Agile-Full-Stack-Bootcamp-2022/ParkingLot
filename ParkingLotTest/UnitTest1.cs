using System.Collections;
using System.Collections.Generic;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class UnitTest1
    {
        public UnitTest1()
        {
        }

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
            //then
            var parkingException = Assert.Throws<ParkingException>(() => parkingBoy.PickUp(null));
            Assert.Equal("Please provide your parking ticket.", parkingException.Message);
        }

        [Fact]
        public void Should_return_null_when_given_ticket_not_in_lot()
        {
            //given
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
            //then
            var parkingException = Assert.Throws<ParkingException>(() => parkingBoy.PickUp(new Ticket(new Car())));
            Assert.Equal("Unrecognized parking ticket.", parkingException.Message);
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

            //then
            var parkingException = Assert.Throws<ParkingException>(() => parkingBoy.PickUp(ticket));
            Assert.Equal("Unrecognized parking ticket.", parkingException.Message);
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
            //then
            var lotFullException = Assert.Throws<LotFullException>(() => parkingBoy.Parking(car3));
            Assert.Equal("Not enough positions.", lotFullException.Message);
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
            //then
            var lotFullException =
                Assert.Throws<LotFullException>(() => parkingBoy.Parking(new List<Car>() { car2, car3 }));
            Assert.Equal("Not enough positions.", lotFullException.Message);
        }

        [Fact]
        public void Should_can_not_parking_when_lot_not_set_and_parking_10()
        {
            //given
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
            var car = new Car();

            for (var i = 0; i < 10; i++)
            {
                parkingBoy.Parking(new Car());
            }

            //when
            //then
            var lotFullException = Assert.Throws<LotFullException>(() => parkingBoy.Parking(car));
            Assert.Equal("Not enough positions.", lotFullException.Message);
        }

        [Fact]
        public void Should_parking_to_lot_2_when_parking_given_parking_boy_has_two_lot_and_lot1_is_full()
        {
            //given
            var lot1 = new Lot(1);
            var lot2 = new Lot(2);
            var parkingBoy = new ParkingBoy(new List<Lot>() { lot1, lot2 });
            parkingBoy.Parking(new Car());
            var car = new Car();
            //when
            var ticket = parkingBoy.Parking(car);
            //then
            Assert.Equal(car, lot2.PickUpCar(ticket));
        }

        [Fact]
        public void Should_can_pick_up_when_boy_has_two_lot_and_parking_to_lot2()
        {
            //given
            var lot1 = new Lot(1);
            var lot2 = new Lot(2);
            var parkingBoy = new ParkingBoy(new List<Lot>() { lot1, lot2 });
            parkingBoy.Parking(new Car());
            var car = new Car();
            var ticket = parkingBoy.Parking(car);
            //when
            var pickUp = parkingBoy.PickUp(ticket);
            //then
            Assert.Equal(car, pickUp);
        }

        [Fact]
        public void Should_can_bath_parking_given_boy_has_two_lot_and_one_is_over_size()
        {
            //given
            var lot1 = new Lot(1);
            var lot2 = new Lot(2);
            var parkingBoy = new ParkingBoy(new List<Lot>() { lot1, lot2 });
            var car1 = new Car();
            var car2 = new Car();
            //when
            var tickets = parkingBoy.Parking(new List<Car>() { car1, car2 });
            //then
            Assert.Equal(car1, lot1.PickUpCar(tickets[0]));
            Assert.Equal(car2, lot2.PickUpCar(tickets[1]));
        }

        [Fact]
        public void Should_parking_success_when_parking_2_and_have_two_lot_each_has_1_position()
        {
            var lot1 = new Lot(1);
            var lot2 = new Lot(1);
            var parkingBoy = new ParkingBoy(new List<Lot>() { lot1, lot2 });
            var car1 = new Car();
            var car2 = new Car();
            //when
            var tickets = parkingBoy.Parking(new List<Car>() { car1, car2 });
            //then
            Assert.Equal(car1, lot1.PickUpCar(tickets[0]));
            Assert.Equal(car2, lot2.PickUpCar(tickets[1]));
        }
    }

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_parking_to_lot_2_when_parking_given_smart_parking_boy_has_two_lot_and_lot1_has_1_position_and_lot2_has_2position()
        {
            //given
            var lot1 = new Lot(2);
            var lot2 = new Lot(2);
            var parkingBoy = new SmartParkingBoy(new List<Lot>() { lot1, lot2 });
            parkingBoy.Parking(new Car());
            var car = new Car();
            //when
            var ticket = parkingBoy.Parking(car);
            //then
            Assert.Equal(car, lot2.PickUpCar(ticket));
        }

        [Fact]
        public void Should_batch_parking_to_lot_2_when_parking_given_smart_parking_boy_has_two_lot_and_lot1_has_1_position_and_lot2_has_2position()
        {
            //given
            var lot1 = new Lot(2);
            var lot2 = new Lot(3);
            var parkingBoy = new SmartParkingBoy(new List<Lot>() { lot1, lot2 });
            var car1 = new Car();
            var car2 = new Car();
            //when
            var tickets = parkingBoy.Parking(new List<Car>() { car1, car2 });
            //then
            Assert.Equal(car1, lot2.PickUpCar(tickets[0]));
            Assert.Equal(car2, lot1.PickUpCar(tickets[1]));
        }

        [Fact]
        public void Should_parking_success_when_parking_2_and_have_two_lot_each_has_1_position()
        {
            var lot1 = new Lot(1);
            var lot2 = new Lot(1);
            var parkingBoy = new SmartParkingBoy(new List<Lot>() { lot1, lot2 });
            var car1 = new Car();
            var car2 = new Car();
            //when
            var tickets = parkingBoy.Parking(new List<Car>() { car1, car2 });
            //then
            Assert.Equal(car1, lot1.PickUpCar(tickets[0]));
            Assert.Equal(car2, lot2.PickUpCar(tickets[1]));
        }
    }

    public class SuperSmartParkingBoyTest
    {
        [Fact]
        public void Should_parking_to_lot_2_when_parking_given_super_smart_parking_boy_has_two_lot_and_lot1_has_1_position_and_lot2_has_2position()
        {
            //given
            var lot1 = new Lot(20);
            var lot2 = new Lot(2);
            for (var i = 0; i < 15; i++)
            {
                lot1.ParkingCar(new Car());
            }

            var parkingBoy = new SuperSmartParkingBoy(new List<Lot>() { lot1, lot2 });
            var car = new Car();
            //when
            var ticket = parkingBoy.Parking(car);
            //then
            Assert.Equal(car, lot2.PickUpCar(ticket));
        }

        [Fact]
        public void Should_batch_parking_to_lot_2_when_parking_given_super_smart_parking_boy_has_two_lot_and_lot1_has_1_position_and_lot2_has_2position()
        {
            //given
            var lot1 = new Lot(2);
            var lot2 = new Lot(3);
            var parkingBoy = new SuperSmartParkingBoy(new List<Lot>() { lot1, lot2 });
            var car1 = new Car();
            var car2 = new Car();
            //when
            var tickets = parkingBoy.Parking(new List<Car>() { car1, car2 });
            //then
            Assert.Equal(car1, lot1.PickUpCar(tickets[0]));
            Assert.Equal(car2, lot2.PickUpCar(tickets[1]));
        }
    }
}