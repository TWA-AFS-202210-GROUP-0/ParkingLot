namespace ParkingLotTest
{
    using ParkingLot;
    using System;
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

        [Fact]
        public void Should_return_no_car_given_customer_give_the_wrong_ticket_when_fetch_car()
        {
            // given
            Customer customer = new Customer(1);
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);
            ParkBoy parkBoy = new ParkBoy();
            parkBoy.ParkCar(customers);
            customer.TicketID = 2;
            // when
            var exeception = Assert.Throws<ParkingLotException>(() => parkBoy.FetchCar(customer));
            // then
            Assert.Equal("Unrecognized parking ticket.", exeception.Message);
        }

        [Fact]
        public void Should_return_no_car_given_customer_no_give_a_ticket_when_fetch_car()
        {
            // given
            Customer customer = new Customer(1);
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(1));
            ParkBoy parkBoy = new ParkBoy();
            parkBoy.ParkCar(customers);
            customer.HasTicket = false;
            // when
            var exeception = Assert.Throws<ParkingLotException>(() => parkBoy.FetchCar(customer));
            // then
            Assert.Equal("Please provide your parking ticket.", exeception.Message);
        }

        [Fact]
        public void Should_return_no_car_given_customer_give_the_ticket_that_be_used_when_fetch_car()
        {
            // given
            Customer customer = new Customer(1);
            List<Customer> customers = new List<Customer>();
            customers.Add(customer);
            ParkBoy parkBoy = new ParkBoy();
            var tickets = parkBoy.ParkCar(customers);
            tickets[0].IsValid = false;

            // when
            var exeception = Assert.Throws<ParkingLotException>(() => parkBoy.FetchCar(customer));
            // then
            Assert.Equal("Unrecognized parking ticket.", exeception.Message);
        }

        [Fact]
        public void Should_return_no_car_given_park_lot_is_less_when_can_park_car()
        {
            // given
            Customer customer = new Customer(3);
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(1));
            customers.Add(new Customer(2));
            customers.Add(customer);

            ParkBoy parkBoy = new ParkBoy();
            parkBoy.ParkLotCapacity = 2;
            // when
            var exeception = Assert.Throws<ParkingLotException>(() => parkBoy.ParkCar(customers));
            // then
            Assert.Equal("Not enough position.", exeception.Message);
        }

        [Fact]
        public void Should_return_not_enough_position_message_given_without_enough_position_when_fetch_car()
        {
            // given
            Customer customer = new Customer(3);
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(1));
            customers.Add(new Customer(2));
            customers.Add(customer);

            ParkBoy parkBoy = new ParkBoy();
            parkBoy.ParkLotCapacity = 2;

            // when
            var exeception = Assert.Throws<ParkingLotException>(() => parkBoy.ParkCar(customers));
            // then
            Assert.Equal("Not enough position.", exeception.Message);
        }
    }
}