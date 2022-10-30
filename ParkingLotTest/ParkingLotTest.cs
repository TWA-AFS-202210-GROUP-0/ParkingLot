namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_parking_ticket_whren_park_a_car()
        {
            // given
            Car car = new Car() { Name = "Xiaohei", Owner = "laohei" };
            ParkingLot parkingLot = new ParkingLot();

            // when
            var ticket = parkingLot.Park(car);

            // then
            Assert.Equal(car.Name, ticket.Name);
            Assert.Equal(car.Owner, ticket.Owner);
        }
    }
}
