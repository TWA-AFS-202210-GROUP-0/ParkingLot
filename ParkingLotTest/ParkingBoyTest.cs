namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_given_ticket_when_parking_given_car_and_parking_boy()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car("12345");
            //when
            var ticket = parkingBoy.ParkCar(car);
            //then
            Assert.Equal(car.CarID, ticket.CarID);
        }

        [Fact]
        public void Should_given_same_car_when_fetch_car_given_ticket_to_parking_boy()
        {
            //given
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var car = new Car("12345");
            var ticket = parkingBoy.ParkCar(car);
            //when
            var fetchedCar = parkingBoy.FetchCar(ticket);
            //then
            Assert.Equal(car, fetchedCar);
        }
    }
}
