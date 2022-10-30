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

        [Fact]
        public void Should_get_car_when_ShowTicket_Given_cars_id_is_2022()
        {
            //Given
            var mengsCar = new Car()
            {
                VehicleId = "2022",
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
            var fetchedCar = meng.ShowTicketGetCar();
            //Then
            Assert.NotNull(fetchedCar);
        }
    }
}
