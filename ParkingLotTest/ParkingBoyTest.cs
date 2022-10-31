using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_park_in_the_second_lot_when_park_given_the_first_lot_is_at_capacity()
        {
            // given
            ParkingBoy parkingBoy = new ParkingBoy(1, 2);
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };

            // when
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            // then
            Assert.Equal("ParkingLot1", ticket1.ParkingLot);
            Assert.Equal("ParkingLot2", ticket2.ParkingLot);
        }

        [Fact]
        public void Should_park_in_the_more_empty_lot_when_park_given_the_first_lot_is_at_capacity_for_smart_boy()
        {
            // given
            ParkingBoy parkingBoy = new SmartParkingBoy(1, 2);
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };

            // when
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);

            // then
            Assert.Equal("ParkingLot2", ticket1.ParkingLot);
            Assert.Equal("ParkingLot1", ticket2.ParkingLot);
        }

        [Fact]
        public void Should_get_parking_tickets_smartly_when_park_cars_given_a_smart_boy()
        {
            // given
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };
            Car car3 = new Car() { Name = "Xiaohuang", Owner = "Laohuang" };
            List<Car> cars = new List<Car>() { car1, car2, car3 };
            ParkingBoy parkingBoy = new SmartParkingBoy(3, 2);

            // when
            var tickets = parkingBoy.Park(cars);

            // then
            Assert.Equal(tickets[0].Car, car1);
            Assert.Equal(tickets[1].Car, car2);
            Assert.Equal(tickets[2].Car, car3);
            Assert.Equal("ParkingLot1", tickets[0].ParkingLot);
            Assert.Equal("ParkingLot1", tickets[1].ParkingLot);
            Assert.Equal("ParkingLot2", tickets[2].ParkingLot);
        }

        [Fact]
        public void Should_get_parking_ticket_when_park_a_car_given_a_parking_lot_and_a_car()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingBoy parkingBoy = new ParkingBoy(1, 2);

            // when
            var ticket = parkingBoy.Park(car);

            // then
            Assert.Equal(car, ticket.Car);
        }

        [Fact]
        public void Should_get_parking_tickets_when_park_cars_given_a_parking_lot_and_cars()
        {
            // given
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };
            Car car3 = new Car() { Name = "Xiaohuang", Owner = "Laohuang" };
            List<Car> cars = new List<Car>() { car1, car2, car3 };
            ParkingBoy parkingBoy = new ParkingBoy(1, 2);

            // when
            var tickets = parkingBoy.Park(cars);

            // then
            Assert.Equal(tickets[0].Car, car1);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_park_cars_given_a_wrong_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingBoy parkingBoy = new ParkingBoy(1, 2);
            parkingBoy.Park(car);
            var ticket = new Ticket() { Car = car, ParkingLot = "ParkingLot1" };

            // given
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingBoy.Fetch(ticket); });
            Assert.Equal("Unrecognized parking ticket.", ex.Message);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_park_cars_given_a_used_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingBoy parkingBoy = new ParkingBoy(1, 2);
            var ticket = parkingBoy.Park(car);
            var parkedCar = parkingBoy.Fetch(ticket);
            Assert.Equal(parkedCar, car);
            Assert.True(ticket.IsUsed);

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingBoy.Fetch(ticket); });
            Assert.Equal("Unrecognized parking ticket.", ex.Message);
        }

        [Fact]
        public void Should_NOT_get_ticket_when_park_cars_given_parking_lot_is_at_capacity()
        {
            // given
            Car car1 = new Car() { Name = "Xiaohei", Owner = "Laohei" };
            Car car2 = new Car() { Name = "Xiaobai", Owner = "Laobai" };
            Car car3 = new Car() { Name = "Xiaohuang", Owner = "Laohuang" };

            ParkingBoy parkingBoy = new ParkingBoy(1, 1);
            var ticket1 = parkingBoy.Park(car1);
            var ticket2 = parkingBoy.Park(car2);
            Assert.NotNull(ticket1);
            Assert.NotNull(ticket2);

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingBoy.Park(car3); });
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
            ParkingBoy parkingBoy = new ParkingBoy(1, 1);

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingBoy.Park(cars); });
            Assert.Equal("Not enough position.", ex.Message);
        }

        [Fact]
        public void Should_NOT_get_CAR_when_fetch_car_given_no_ticket()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingBoy parkingBoy = new ParkingBoy(1, 1);
            parkingBoy.Park(car);

            // when
            // then
            Exception ex = Assert.Throws<Exception>(() => { parkingBoy.Fetch(null); });
            Assert.Equal("Please provide your parking ticket.", ex.Message);
        }
    }
}
