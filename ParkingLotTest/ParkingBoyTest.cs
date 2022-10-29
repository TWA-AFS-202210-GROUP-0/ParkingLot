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

        [Fact]
        public void Should_throw_exception_when_fetch_given_used_ticket()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car("12345");
            var ticket = parkingBoy.ParkCar(car);
            parkingBoy.FetchCar(ticket);
            //when
            //then
            Assert.Throws<WrongTicketException>(() => parkingBoy.FetchCar(ticket));

        }

        [Fact]
        public void Should_return_null_when_park_given_a_parking_lot_capicity_10_has_parked_10_cars()
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
            var ticket = parkingBoy.ParkCar(car);
            //then
            Assert.Equal(null, ticket);

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
            var carList = new List<Car>();
            carList.Add(car10);
            carList.Add(car11);
            //when
            var ticketList = parkingBoy.ParkSeveralCars(carList);
            //then
            Assert.Equal(car10, parkingBoy.FetchCar(ticketList[0]));
            Assert.Null(ticketList[1]);

        }


    }
}
