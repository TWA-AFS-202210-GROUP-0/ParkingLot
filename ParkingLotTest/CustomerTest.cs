using System;
using Moq;

namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class CustomerTest
    {
        [Fact]
        public void Should_get_ticket_When_HandOverCar_Given_mocked_parkingboy()
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
            var mockParkingBoy = new Mock<IParkingBoy>();
            mockParkingBoy.Setup(m => m.ParkCar(It.IsAny<Car>())).Returns("dummy ticket");
            //When
            var parkResult = meng.HandOverCar(mockParkingBoy.Object);
            //Then
            Assert.Equal("Parked car with ticket = dummy ticket", parkResult);
        }

        [Fact]
        public void Should_return_error_message_When_HandOverCar_Given_mocked_parkingBoy()
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
            var mockParkingBoy = new Mock<IParkingBoy>();
            mockParkingBoy.Setup(m => m.ParkCar(It.IsAny<Car>())).Throws(new Exception("dummy exception"));
            //When
            var parkResult = meng.HandOverCar(mockParkingBoy.Object);
            //Then
            Assert.Equal("dummy exception", parkResult);
        }

        [Fact]
        public void Should_get_car_when_ShowTicket_Given_cars_id_is_2022_and_mocked_parkingBoy()
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
            var mockParkingBoy = new Mock<IParkingBoy>();
            mockParkingBoy.Setup(m => m.FetchCar(It.IsAny<string>())).Returns(mengsCar);
            //When
            var fetchResult = meng.ShowTicketGetCar(mockParkingBoy.Object);
            //Then
            Assert.Equal("Fetched my car", fetchResult);
        }

        [Fact]
        public void Should_return_error_message_when_ShowTicket_Given_mocked_parkingboy()
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
            var mockParkingBoy = new Mock<IParkingBoy>();
            mockParkingBoy.Setup(m => m.FetchCar(It.IsAny<string>())).Throws(new Exception("dummy exception"));
            //When
            var fetchResult = meng.ShowTicketGetCar(mockParkingBoy.Object);
            //Then
            Assert.Equal("dummy exception", fetchResult);
        }
    }
}
