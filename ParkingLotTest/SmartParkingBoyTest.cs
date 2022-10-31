namespace ParkingLotTest
{
    using Moq;
    using ParkingLot;
    using System.Collections.Generic;
    using Xunit;

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_park_to_parking_lot_has_most_available_positions_when_park_given_three_parking_lots()
        {
            // given
            Car car = new Car("12345");
            var parkingLot1 = new Mock<ParkingLot>(5);
            var parkingLot2 = new Mock<ParkingLot>(10);
            var parkingLot3 = new Mock<ParkingLot>(15);
            SmartParkingBoy parkingBoy = new SmartParkingBoy(new List<ParkingLot>
            {
                parkingLot1.Object,
                parkingLot2.Object,
                parkingLot3.Object,
            });

            // when
            Ticket ticket = parkingBoy.ParkCar(car);

            // then
            parkingLot3.Verify(parkingLot => parkingLot.ParkCar(car));
        }

    }
}
