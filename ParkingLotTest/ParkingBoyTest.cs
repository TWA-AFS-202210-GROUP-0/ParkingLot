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
            var carList = new List<Car>() { car1, car2 };
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
        public void Should_throw_exception_with_right_message_when_fetch_given_no_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            //when
            //then
            NoTicketException exception = Assert.Throws<NoTicketException>(() => parkingBoy.FetchCar(null));
            Assert.Equal("Please provide your parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_with_right_message_when_fetch_given_used_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car("12345");
            var ticket = parkingBoy.ParkCar(car);
            parkingBoy.FetchCar(ticket);
            //when
            //then
            WrongTicketException exception = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(ticket));
            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_throw_exception_with_right_message_when_park_given_a_parking_lot_capicity_10_has_parked_10_cars()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            for (int carIndex = 0; carIndex < 10; carIndex++)
            {
                string carID = carIndex.ToString();
                parkingBoy.ParkCar(new Car(carID));
            }

            var car = new Car("11");
            //when
            NoPositionException exception = Assert.Throws<NoPositionException>(() => parkingBoy.ParkCar(car));
            Assert.Equal("Not enough position.", exception.Message);

        }

        [Fact]
        public void Should_return_list_contains_null_when_park_2_cars_given_a_parking_lot_capicity_10_has_parked_9_cars()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            for (int carIndex = 0; carIndex < 9; carIndex++)
            {
                string carID = carIndex.ToString();
                parkingBoy.ParkCar(new Car(carID));
            }
            var car10 = new Car("10");
            var car11 = new Car("11");
            var carList = new List<Car>() { car10, car11 };
            //when
            var ticketList = parkingBoy.ParkSeveralCars(carList);
            //then
            Assert.Equal(car10, parkingBoy.FetchCar(ticketList[0]));
            Assert.Null(ticketList[1]);
        }

        [Fact]
        public void Should_throw_exception_when_park_given_null_car_or_parked_car()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car("12345");
            parkingBoy.ParkCar(car);
            var car2 = new Car("12345");
            //when
            //then
            Assert.Throws<WrongCarException>(() => parkingBoy.ParkCar(null));
            Assert.Throws<WrongCarException>(() => parkingBoy.ParkCar(car2));

        }
    }
}
