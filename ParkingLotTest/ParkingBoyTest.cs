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
    }
}
