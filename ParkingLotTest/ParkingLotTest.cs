namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_parking_ticket_when_park_a_car_given_a_parking_lot_and_a_car()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot();

            // when
            var ticket = parkingLot.Park(car);

            // then
            Assert.Equal(car, ticket.Car);
        }

        [Fact]
        public void Should_get_car_when_fetch_a_car_given_a_ticket_and_a_parking_lot()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot();
            var ticket = parkingLot.Park(car);

            // when
            var parkedCar = parkingLot.Fetch(ticket);

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
            ParkingLot parkingLot = new ParkingLot();

            // when
            var tickets = parkingLot.Park(cars);

            // then
            Assert.Equal(tickets[0].Car, car1);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_park_cars_given_a_wrong_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot();
            parkingLot.Park(car);
            var ticket = new Ticket() { Car = car };

            // when
            var parkedCar = parkingLot.Fetch(ticket);

            // then
            Assert.Null(parkedCar);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_park_cars_given_a_used_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot();
            var ticket = parkingLot.Park(car);
            var parkedCar = parkingLot.Fetch(ticket);
            Assert.Equal(parkedCar, car);
            Assert.True(ticket.IsUsed);

            // when
            parkedCar = parkingLot.Fetch(ticket);

            // then
            Assert.Null(parkedCar);
        }
    }
}
