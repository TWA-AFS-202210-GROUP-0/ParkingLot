using ParkingLot;

namespace ParkingLotTest
{
    using ParkingLot;
    using System;
    using System.Collections.Generic;
    using System.Runtime.ConstrainedExecution;
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
            var ticket = boy.ParkOneCar(car, 1);
            var fetchedCar = boy.FetchOneCar(ticket);
            // then
            Assert.Equal(1, boy.Tickets.Count);
            Assert.Equal("AUCCD", ticket.CarName);
            Assert.Equal("AUCCD", fetchedCar);
        }

        [Fact]
        public void Should_return_finishing_parkig_Multiple_Cars_and_RightCars_ticket_when_parks_given_many_cars()
        {
            //given
            var carOne = new Car("AUCCD");
            var carTwo = new Car("QWEGY");
            var carThree = new Car("WEHDJ");
            List<Car> cars = new List<Car>() { carOne, carTwo, carThree };
            var shouldParledCars = new List<string>() { "AUCCD", "QWEGY" };
            var parkingLot = new ParkLot(2);
            var boy = new ParkingBoy(parkingLot);
            //when
            var tickets = boy.ParkingCar(cars);
            var fetchedCar = boy.FetchCar(tickets);
            // then
            Assert.Equal(2, tickets.Count);
            Assert.Equal(shouldParledCars, fetchedCar);
        }

        [Fact]
        public void Should_return_NOTENOUGHPOSITIONS_and_RightCars_ticket_when_parks_given_many_cars()
        {
            //given
            var carOne = new Car("AUCCD");
            var carTwo = new Car("QWEGY");
            var carThree = new Car("WEHDJ");
            List<Car> cars = new List<Car>() { carOne, carTwo, carThree };
            var shouldParledCars = new List<string>() { "AUCCD", "QWEGY" };
            var parkingLot = new ParkLot(2);
            var boy = new ParkingBoy(parkingLot);
            //when
            var tickets = boy.ParkingCar(cars);
            var fetchedCar = boy.FetchCar(tickets);
            // then
            Assert.Equal(2, tickets.Count);
            Assert.Equal(shouldParledCars, fetchedCar);
            Assert.Equal("Not enough position.", boy.ParkErrorMessage);
        }

        [Fact]
        public void Should_return_UnrecognizedCar_and_NullTicket_and_RightCars_ticket_when_parks_given_many_cars()
        {
            //given
            var carOne = new Car("AUCCD");
            var carTwo = new Car("QWEGY");
            var carThree = new Car("WEHDJ");
            List<Car> cars = new List<Car>() { carOne, carTwo, carThree };
            var shouldParledCars = new List<string>() { "AUCCD", "QWEGY" };
            var parkingLot = new ParkLot(2);
            var boy = new ParkingBoy(parkingLot);
            Ticket fakedTicket = new Ticket();
            fakedTicket.CarName = carThree.Name;
            fakedTicket.TicketNumber = Guid.NewGuid().ToString();
            fakedTicket.Position = 9;
            //when
            var tickets = boy.ParkingCar(cars);
            tickets.Add(fakedTicket);
            tickets.Add(null);
            var fetchedCar = boy.FetchCar(tickets);
            // then
            Assert.Equal(shouldParledCars, fetchedCar);
            Assert.Equal("Unrecognized parking ticket.Please provide your parking ticket.", boy.FetchErrorMessage);
        }
    }
}
