namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_given_ticket_when_parking_given_car_and_parking_boy()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car("12345");
            //when
            var ticket = parkingBoy.ParkCar(car);
            //then
            Assert.Equal("12345", car.CarID);
        }

        [Fact]
        public void Should_given_same_car_when_fetch_car_given_ticket_to_parking_boy()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car("12345");
            var ticket = parkingBoy.ParkCar(car);
            //when
            var fetchedCar = parkingBoy.FetchCar(ticket);
            //then
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Should_given_right_car_when_fetch_given_correspoding_ticket_to_parking_boy()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car1 = new Car("12345");
            var car2 = new Car("56789");
            var carList = new List<Car>();
            carList.Add(car1);
            carList.Add(car2);
            var ticketList = parkingBoy.ParkSeveralCars(carList);
            //when
            Car fetchedCar = parkingBoy.FetchCar(ticketList[0]);
            //then
            Assert.Equal(car1, fetchedCar);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_wrong_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var wrongTicket = new Ticket("12345");
            //when
            //then
            Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(wrongTicket));

        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_no_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            //when
            //then
            Assert.Throws<NoTicketException>(() => parkingBoy.FetchCar(null));

        }
    }
}
