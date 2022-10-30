using ParkingLot;

namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class ParkLotTest
    {
        [Fact]
        public void Should_return_finishing_parkig_Car_and_its_ticket_when_parks_given_one_car()
        {
            //given
            var car = new Car("AUCCD");
            var parkingLot = new ParkLot(1);
            var boy = new ParkingBoy(parkingLot);
            //when
            var ticket = boy.ParkingCar(car);
            // then
            Assert.Equal(1, boy.Tickets.Count);
        }
    }
}
