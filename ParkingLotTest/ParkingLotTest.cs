using System;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_park_car_When_HandOverCar_Given_NormalParkingBoy()
        {
            //Given
            var mengsCar = new Car()
            {
                VehicleId = Guid.NewGuid().ToString(),
            };
            var meng = new Customer()
            {
                Name = "Meng",
                Car = mengsCar,
            };
            var normalParkingBoy = new NormalParkingBoy();
            var parkingLot = new ParkingLot()
            {
                Capacity = 2,
            };
            //When
            meng.HandOverCar();
            //Then
            Assert.NotNull(meng.Ticket);
        }
    }
}
