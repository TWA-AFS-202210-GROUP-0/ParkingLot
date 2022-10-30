namespace ParkingLotTest
{
    using ParkingLot;
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
    }
}
