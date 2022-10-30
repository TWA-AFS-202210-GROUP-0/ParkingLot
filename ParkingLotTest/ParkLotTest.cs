namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkLotTest
    {
        [Fact]
        public void Should_return_finishing_parkig_Car_and_its_ticket_when_parks_given_one_car()
        {
            var car = new Car();
            var parkingLot = new ParkingLot()l;
            var boy = new ParkingBoy();
            var ticket = new Ticket();
            parkingLot.Car = car;
            Assert.NotNull(class1);
        }
    }
}
