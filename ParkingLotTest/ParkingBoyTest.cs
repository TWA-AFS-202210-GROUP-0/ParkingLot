using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Shoule_return_ticket_when_parkingBoy_park_car_given_a_parkingBoy_and_a_car()
        {
            // given
            ParkingBoy parkingBoy = new ParkingBoy();
            Car car = new Car();
            // when
            var ticket = parkingBoy.Park(car);
            // then
            Assert.Equal(typeof(Ticket), ticket.GetType());
        }
    }
}
