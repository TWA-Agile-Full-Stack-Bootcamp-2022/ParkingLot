namespace ParkingLotTest
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using ParkingLot;
    using Xunit;

    public class ParkingLotServiceManagerTest
    {
        [Theory]
        [InlineData("1234")]
        public void Parking_lot_service_manager_can_add_parking_boys_to_management_list_and_parking_lot_manager_can_specify_a_parking_boy_on_list_to_park_or_fetch_car_only_from_parking_lots_managed_by_that_parking_boy(string licensePlate)
        {
            // given
            Car car = new Car { LicensePlate = licensePlate, };
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            ParkingLot parkingLot3 = new ParkingLot();
            ParkingBoy parkingBoy1 = new ParkingBoy { ParkingLots = new List<ParkingLot> { parkingLot1 } };
            ParkingBoy parkingBoy2 = new ParkingBoy { ParkingLots = new List<ParkingLot> { parkingLot2 } };
            ParkingBoy parkingBoy3 = new ParkingBoy { ParkingLots = new List<ParkingLot> { parkingLot3 } };

            // NOTE: the ParkingLots of the parkingLotServiceManager have to be given otherwise the Locate of parkingLotServiceManager.FetchCar throw error that complain ParkingLots is null
            ParkingLotServiceManager parkingLotServiceManager = new ParkingLotServiceManager { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            parkingLotServiceManager.AddParkingBoy(parkingBoy1);
            parkingLotServiceManager.AddParkingBoy(parkingBoy2);
            parkingLotServiceManager.AddParkingBoy(parkingBoy3);

            // when
            var ticket = parkingLotServiceManager.SpecifyParkingBoyToParkCar(car);

            // then
            Assert.Equal(new List<ParkingBoy> { parkingBoy1, parkingBoy2, parkingBoy3 }, parkingLotServiceManager.ManagementList);
            Assert.IsType<ParkingTicket>(ticket);
            Assert.Equal(car, parkingLotServiceManager.FetchCar(ticket));
        }

        [Theory]
        [InlineData("1234")]
        // NOTE: same pattern as ParkingBoyTest.Parking_boy_can_park_a_car_into_parking_lot_and_returns_a_parking_ticket_which_could_be_used_to_fetch_car
        public void Parking_lot_service_manager_can_also_manage_parking_lots_and_he_can_park_or_fetch_car_just_as_a_standard_parking_boy_story_and_he_can_only_store_and_fetch_car_from_his_her_own_parking_lots(string licensePlate)
        {
            // given
            ParkingLot parkingLot = new ParkingLot();
            ParkingLotServiceManager parkingLotServiceManager = new ParkingLotServiceManager { ParkingLots = new List<ParkingLot> { parkingLot } };
            Car car = new Car { LicensePlate = licensePlate, };

            // when
            var ticket = parkingLotServiceManager.ParkCar(car);

            // then
            Assert.Equal(1, ParkingLot.Capacity - parkingLot.NumOfEmptyPositions);
            Assert.IsType<ParkingTicket>(ticket);
            Assert.Equal(car, parkingLotServiceManager.FetchCar(ticket));
        }

        [Theory]
        [InlineData("1234", "2345", "3456", "4567", "5678", "6789", "7890", "8901", "9012", "0123")]
        // NOTE: same pattern as ParkingBoyTest.When_parking_boy_attempt_to_park_a_car_into_a_parking_lot_without_a_position_error_message_should_be_not_enough_position
        public void Manager_should_be_able_to_display_error_message_to_customer_if_parking_boy_failed_to_do_operation(params string[] licensePlates)
        {
            // given
            var cars = licensePlates.Select(licensePlate => new Car { LicensePlate = licensePlate, });
            Assert.Equal(10, cars.Count());
            ParkingBoy parkingBoy = new ParkingBoy { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            ParkingLotServiceManager parkingLotServiceManager = new ParkingLotServiceManager { ParkingLots = new List<ParkingLot> { new ParkingLot() } };
            parkingLotServiceManager.AddParkingBoy(parkingBoy);

            // when
            var tickets = cars.Select(parkingLotServiceManager.SpecifyParkingBoyToParkCar);
            Assert.Equal(10, tickets.Count());
            void Action() => parkingLotServiceManager.SpecifyParkingBoyToParkCar(new Car { LicensePlate = "1111", });

            // then
            var exception = Assert.Throws<InvalidOperationException>(Action);
            Assert.Equal("Not enough position.", exception.Message);
        }
    }
}
