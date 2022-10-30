namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_parking_ticket_when_park_a_car_given_a_parking_lot_and_a_car()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot("parkinglot");

            // when
            var ticket = parkingLot.BeParked(car);

            // then
            Assert.Equal(car, ticket.Car);
        }

        [Fact]
        public void Should_get_car_when_fetch_a_car_given_a_ticket_and_a_parking_lot()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot("parkinglot");
            var ticket = parkingLot.BeParked(car);

            // when
            var parkedCar = parkingLot.BeFetched(ticket);

            // then
            Assert.Equal(car.Name, parkedCar.Name);
            Assert.Equal(car.Owner, parkedCar.Owner);
        }

        [Fact]
        public void Should_get_parking_tickets_when_park_cars_given_a_parking_lot_and_cars()
        {
            // given
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };
            Car car3 = new Car() { Name = "Xiaohuang", Owner = "Laohuang" };
            List<Car> cars = new List<Car>() { car1, car2, car3 };
            ParkingLot parkingLot = new ParkingLot("parkinglot");

            // when
            var tickets = parkingLot.BeParked(cars);

            // then
            Assert.Equal(tickets[0].Car, car1);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_park_cars_given_a_wrong_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot("parkinglot");
            parkingLot.BeParked(car);
            var ticket = new Ticket() { Car = car };

            // given
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingLot.BeFetched(ticket); });
            Assert.Equal("Unrecognized parking ticket.", ex.Message);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_park_cars_given_a_used_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot("parkinglot");
            var ticket = parkingLot.BeParked(car);
            var parkedCar = parkingLot.BeFetched(ticket);
            Assert.Equal(parkedCar, car);
            Assert.True(ticket.IsUsed);

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingLot.BeFetched(ticket); });
            Assert.Equal("Unrecognized parking ticket.", ex.Message);
        }

        [Fact]
        public void Should_NOT_get_ticket_when_park_cars_given_parking_lot_is_at_capacity()
        {
            // given
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };
            Car car3 = new Car() { Name = "Xiaohuang", Owner = "Laohuang" };
            ParkingLot parkingLot = new ParkingLot("parkinglot", 2);
            var ticket1 = parkingLot.BeParked(car1);
            var ticket2 = parkingLot.BeParked(car2);
            Assert.NotNull(ticket1);
            Assert.NotNull(ticket2);

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingLot.BeParked(car3); });
            Assert.Equal("Not enough position.", ex.Message);
        }

        [Fact]
        public void Should_NOT_get_last_ticket_when_park_cars_given_parking_lot_is_at_capacity()
        {
            // given
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };
            Car car3 = new Car() { Name = "Xiaohuang", Owner = "Laohuang" };
            List<Car> cars = new List<Car>() { car1, car2, car3 };
            ParkingLot parkingLot = new ParkingLot("parkinglot", 2);

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingLot.BeParked(cars); });
            Assert.Equal("Not enough position.", ex.Message);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_fetch_car_given_no_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot("parkinglot");
            parkingLot.BeParked(car);
            var ticket = new Ticket() { Car = car };

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingLot.BeFetched(null); });
            Assert.Equal("Please provide your parking ticket.", ex.Message);
        }
    }
}
