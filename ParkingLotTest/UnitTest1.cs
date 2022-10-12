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
            Car pickUpCar = parkingBoy.PickUp(ticket);
            //then
            Assert.Equal(car, pickUpCar);
        }

        [Fact]
        public void Should_return_tickets_when_batch_parking_car_given_parking_boy_and_cars()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            var paringLot = new Lot();
            var parkingBoy = new ParkingBoy(paringLot);
            //when
            var tickets = parkingBoy.Parking(cars);
            //then
            Assert.Equal(car1, tickets[0].GetCar());
            Assert.Equal(car2, tickets[1].GetCar());
            Assert.Equal(car3, tickets[2].GetCar());
        }
    }
}
