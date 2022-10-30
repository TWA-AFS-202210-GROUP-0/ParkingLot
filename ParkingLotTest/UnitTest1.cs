namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void Should_return_a_ticket_when_boy_park_the_car()
        {
            // given
            Car car = new Car(1);
            List<Car> cars = new List<Car>();
            cars.Add(car);
            ParkBoy parkBoy = new ParkBoy(cars);

            // when
            var tickets = parkBoy.ParkCar();
            // then
            Assert.Single(tickets);
            Assert.Equal(1, tickets[0].Id);
        }
    }
}