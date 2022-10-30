using ParkingLot;
using System.Collections.Generic;
using System.Net.Sockets;
using Xunit;

namespace ParkingLotTest;

public class ParkingBoyTest
{
    [Fact]
    public void Should_return_ticket_when_parkingBoy_manage_a_parklot_with_default_capacity_and_park_car_given_a_parkingBoy_and_a_car()
    {
        // given
        ParkingBoy parkingBoy = new ParkingBoy();
        Car car = new Car();
        SingleParkingLot parkingLot = new SingleParkingLot();
        // when
        parkingBoy.Manage(parkingLot);
        var ticket = parkingBoy.Park(car);
        // then
        Assert.Equal(typeof(Ticket), ticket.GetType());
    }

    [Fact]
    public void Should_return_car_when_parkingBoy_get_a_vilid_ticket_given_a_car_park_in_a_SingleParkingLot_managed_by_a_parkingBoy()
    {
        // given
        ParkingBoy parkingBoy = new ParkingBoy();
        Car car = new Car();
        SingleParkingLot parkingLot = new SingleParkingLot();
        parkingBoy.Manage(parkingLot);
        var ticket = parkingBoy.Park(car);
        // when
        var fetchedCar = parkingBoy.Fetch(ticket);
        // then
        Assert.Equal(car, fetchedCar);
    }

    [Fact]
    public void Should_return_several_ticket_when_parkingBoy_manage_a_parklot_with_default_capacity_and_park_several_cars_given_SingleParkingLot_managed_by_a_parkingBoy_and_3_cars()
    {
        // given
        ParkingBoy parkingBoy = new ParkingBoy();
        var cars = new List<Car>();
        for (int i = 0; i < 3; i++)
        {
            cars.Add(new Car());
        }

        SingleParkingLot parkingLot = new SingleParkingLot();
        parkingBoy.Manage(parkingLot);
        // when
        var tickets = parkingBoy.ParkSeveral(cars);
        // then
        Assert.Equal(typeof(List<Ticket>), tickets.GetType());
    }

    [Fact]
    public void Should_return_correspond_car_when_parkingBoy_fetch_with_a_vilid_ticket_given_SingleParkingLot_managed_by_a_parkingBoy_with_3_cars_parking()
    {
        // given
        ParkingBoy parkingBoy = new ParkingBoy();
        var cars = new List<Car>();
        for (int i = 0; i < 3; i++)
        {
            cars.Add(new Car());
        }

        Car car = new Car();

        SingleParkingLot parkingLot = new SingleParkingLot();
        parkingBoy.Manage(parkingLot);
        var tickets = parkingBoy.ParkSeveral(cars);
        var ticket = parkingBoy.Park(car);
        // when
        var fetchedCar = parkingBoy.Fetch(ticket);
        // then
        Assert.Equal(car, fetchedCar);
    }

    [Fact]
    public void Should_return_response_message_when_parkingBoy_fetch_given_a_parkingBoy_get_a_wrong_ticket()
    {
        // given
        ParkingBoy parkingBoy = new ParkingBoy();
        var cars = new List<Car>();
        for (int i = 0; i < 3; i++)
        {
            cars.Add(new Car());
        }

        SingleParkingLot parkingLot = new SingleParkingLot();
        parkingBoy.Manage(parkingLot);
        var tickets = parkingBoy.ParkSeveral(cars);
        var ticket = new Ticket();
        // when
        ExpectedException ex = Assert.Throws<ExpectedException>(() => parkingBoy.Fetch(ticket));
        // then
        Assert.Equal("Unrecognized parking ticket.", ex.Message);
    }

    [Fact]
    public void Should_return_response_message_when_parkingBoy_fetch_given_a_parkingBoy_get_a_used_ticket()
    {
        // given
        ParkingBoy parkingBoy = new ParkingBoy();
        var cars = new List<Car>();
        for (int i = 0; i < 3; i++)
        {
            cars.Add(new Car());
        }

        SingleParkingLot parkingLot = new SingleParkingLot();
        parkingBoy.Manage(parkingLot);
        var tickets = parkingBoy.ParkSeveral(cars);
        var fetchedCar1 = parkingBoy.Fetch(tickets[0]);
        // when
        ExpectedException ex = Assert.Throws<ExpectedException>(() => parkingBoy.Fetch(tickets[0]));
        // then
        Assert.Equal("Unrecognized parking ticket.", ex.Message);
    }

    [Fact]
    public void Should_return_null_when_parkingBoy_park_given_a_parkingBoy_manage_a_parklot_with_default_capacity_and_full()
    {
        // given
        ParkingBoy parkingBoy = new ParkingBoy();
        var cars = new List<Car>();
        for (int i = 0; i < 10; i++)
        {
            cars.Add(new Car());
        }

        SingleParkingLot parkingLot = new SingleParkingLot();
        parkingBoy.Manage(parkingLot);
        var tickets = parkingBoy.ParkSeveral(cars);
        var car = new Car();
        // when
        var ticket = parkingBoy.Park(car);
        // then
        Assert.Equal(null, ticket);
    }
}