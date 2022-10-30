namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;
    public class ParkingBoyManageTwoLotsTest
    {
        [Fact]
        public void Should_park_to_second_parking_lot_when_park_given_first_parking_lot_is_full()
        {
            //given
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new Mock<ParkingLot>(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2.Object});
            var car1 = new Car("12345");
            parkingBoy.ParkCar(car1);
            //Assert.True(parkingLot1.IsFull());
            var car2 = new Car("56789");
            //when
            var ticket = parkingBoy.ParkCar(car2);
            //then
            parkingLot2.Verify(_ => _.ParkCar(car2));
        }

        [Fact]
        public void Should_park_to_second_parking_lot_when_park_two_cars_given_two_parking_lots_caplicity_1()
        {
            //given
            var parkingLot1 = new ParkingLot(1);
            var parkingLot2 = new Mock<ParkingLot>(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot> { parkingLot1, parkingLot2.Object });
            var car1 = new Car("12345");
            var car2 = new Car("56789");
            var carList = new List<Car>() { car1, car2 };
            //when
            var ticketList = parkingBoy.ParkSeveralCars(carList);
            //then
            parkingLot2.Verify(_ => _.ParkCar(car2));
        }
    }
}
