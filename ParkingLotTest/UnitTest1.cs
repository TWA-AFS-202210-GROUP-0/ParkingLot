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
            Customer customer = new Customer(1);
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);
            ParkBoy parkBoy = new ParkBoy();

            // when
            var tickets = parkBoy.ParkCar(customers);
            // then
            Assert.Single(tickets);
            Assert.Equal(1, tickets[0].Id);
        }

        [Fact]
        public void Should_return_a_ticket_when_boy_park_the_car_and_customer_fetch_car()
        {
            // given
            Customer customer = new Customer(1);
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);
            ParkBoy parkBoy = new ParkBoy();

            // when
            var tickets = parkBoy.ParkCar(customers);
            var res = parkBoy.FetchCar(customer);
            // then
            Assert.Single(tickets);
            Assert.Equal(1, tickets[0].Id);
            Assert.True(res);
        }
    }
}