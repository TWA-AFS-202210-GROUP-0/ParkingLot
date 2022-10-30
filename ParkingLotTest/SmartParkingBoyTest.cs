using ParkingLot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_parkingLot2_be_called_when_park_given_parkingLot2_contains_more_empty_positions()
        {
            // given
            var car = new Car();
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy();
            var singleParkingLot1 = new Mock<SingleParkingLot>(5);
            var singleParkingLot2 = new Mock<SingleParkingLot>(10);
            var singleParkingLot3 = new Mock<SingleParkingLot>(5);
            smartParkingBoy.Manage(singleParkingLot1.Object);
            smartParkingBoy.Manage(singleParkingLot2.Object);
            smartParkingBoy.Manage(singleParkingLot3.Object);
            // when
            var ticket = smartParkingBoy.Park(car);
            // then
            singleParkingLot2.Verify(_ => _.Park(car));
        }
    }
}
