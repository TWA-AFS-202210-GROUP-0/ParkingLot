using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_park_cars_to_parkingLot1_return_ticket_When_ParkCar_Given_NormalParkingCar()
        {
            //Given
            var car1 = new Car();
            var car2 = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot()
            {
                Capacity = 2,
            };
            var parkingLot2 = new ParkingLot.ParkingLot()
            {
                Capacity = 2,
            };
            var normalParkingBoy = new NormalParkingBoy()
            {
                WorkingParkingLots = new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 },
            };

            //When
            var parkingCarsRespone = normalParkingBoy.ParkCars(new List<Car> { car1, car2 });
            //Then
            Assert.True(parkingCarsRespone.IsAllCarsParked);
            Assert.IsType<string>(parkingCarsRespone.Tickets[0]);
            Assert.Equal(2, parkingLot1.ParkedCars.Count);
        }

        [Fact]
        public void Should_park_the_car_to_parkingLot2_return_ticket_When_ParkCar_Given_SmartParkingCar()
        {
            //Given
            var car1 = new Car();
            var car2 = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot()
            {
                Capacity = 2,
            };
            var parkingLot2 = new ParkingLot.ParkingLot()
            {
                Capacity = 2,
            };
            var smartParkingBoy = new SmartParkingBoy()
            {
                WorkingParkingLots = new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 },
            };

            //When
            var parkingCarsRespone = smartParkingBoy.ParkCars(new List<Car> { car1, car2 });
            //Then
            Assert.True(parkingCarsRespone.IsAllCarsParked);
            Assert.IsType<string>(parkingCarsRespone.Tickets[0]);
            Assert.Equal(1, parkingLot1.ParkedCars.Count);
            Assert.Equal(1, parkingLot2.ParkedCars.Count);
        }

        [Fact]
        public void
            Should_park_1_car_and_return_not_enough_position_When_ParCars_Given_2cars_1parkingLot_NormalParkingBoy()
        {
            //Given
            var car1 = new Car();
            var car2 = new Car();
            var parkingLot1 = new ParkingLot.ParkingLot()
            {
                Capacity = 1,
            };
            var normalParkingBoy = new NormalParkingBoy()
            {
                WorkingParkingLots = new List<ParkingLot.ParkingLot> { parkingLot1 },
            };
            //When
            var parkingCarsRespone = normalParkingBoy.ParkCars(new List<Car> { car1, car2 });
            //Then
            Assert.False(parkingCarsRespone.IsAllCarsParked);
            Assert.Equal(1, parkingCarsRespone.Tickets.Count);
            Assert.Equal("Not enough position", parkingCarsRespone.Message);
        }

        [Fact]
        public void Should_fetch_Car_When_FetchCar_Given_2parkingLots_ticketAs_dummy_ticket()
        {
            //Given
            var ticketGuid = "dummy_ticket_guid";
            var dummyCar = new Car()
            {
                VehicleId = "dummy_car"
            };
            var car2 = new Car();

            var parkingLot1 = new ParkingLot.ParkingLot()
            {
                ParkedCars = new List<Car> { dummyCar },
                TicketCopies = new List<string> { ticketGuid },
            };
            var parkingLot2 = new ParkingLot.ParkingLot()
            {
                ParkedCars = new List<Car> { car2 },
            };

            var parkingBoy = new NormalParkingBoy()
            {
                WorkingParkingLots = new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 },
            };
            var ticketToCustomer = TicketEncoder.Encoder(ticketGuid, 0);
            //When
            var fetchedCar = parkingBoy.FetchCar(ticketToCustomer);
            //Then
            Assert.Equal("dummy_car", fetchedCar.VehicleId);
        }

        [Fact]
        public void Should_return_Please_provide_parking_ticket_when_FetchCar_without_ticket()
        {
            //Given
            var parkingLot = new ParkingLot.ParkingLot();
            var parkingBoy = new NormalParkingBoy();
            //When
            var exception = Record.Exception(() => parkingBoy.FetchCar(string.Empty));
            //Then
            Assert.Equal("Please provide ticket", exception.Message);
        }

        [Fact]
        public void Should_return_Unrecognized_ticket_when_FetchCar_with_used_ticket()
        {
            //Given
            var ticketGuid = "dummy_ticket_guid";
            var dummyCar = new Car()
            {
                VehicleId = "dummy_car"
            };

            var parkingLot1 = new ParkingLot.ParkingLot()
            {
                ParkedCars = new List<Car> { dummyCar },
                TicketCopies = new List<string> { ticketGuid },
            };

            var parkingBoy = new NormalParkingBoy()
            {
                WorkingParkingLots = new List<ParkingLot.ParkingLot> { parkingLot1 },
            };
            var ticketToCustomer = TicketEncoder.Encoder(ticketGuid, 0);
            //When
            var fetchedCar = parkingBoy.FetchCar(ticketToCustomer);
            var exception = Record.Exception(() => parkingBoy.FetchCar(ticketToCustomer));
            //Then
            Assert.Equal("Unrecognized parking ticket", exception.Message);
        }
    }
}
