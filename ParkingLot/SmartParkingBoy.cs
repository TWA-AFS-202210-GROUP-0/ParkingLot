using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        private List<Ticket> parkedTicketList = new List<Ticket>();

        public SmartParkingBoy(List<ParkingLot> workingParkingLots) : base(workingParkingLots)
        {
        }

        public override Ticket ParkCar(Car car)
        {
            CheckNotNullCar(car);

            ParkingLot availableParkingLot = WorkingParkingLots.Where(parkingLot => !parkingLot.IsFull()).OrderByDescending(order => order.AvailablePositions()).FirstOrDefault();
            if (availableParkingLot == null)
            {
                throw new NoPositionException("Not enough position.");
            }

            return ParkCarInSpecificParkingLot(car, availableParkingLot);
        }

        public override ParkingSeveralCarsResponse ParkSeveralCars(List<Car> carList)
        {
            var ticketList = new List<Ticket>();
            foreach (Car car in carList)
            {
                try
                {
                    CheckNotNullCar(car);
                    ParkingLot availableParkingLot = WorkingParkingLots.Where(parkingLot => !parkingLot.IsFull()).OrderByDescending(order => order.AvailablePositions()).FirstOrDefault();
                    if (availableParkingLot == null)
                    {
                        throw new NoPositionException("Not enough position.");
                    }

                    Ticket ticketWhoseParking = ParkCarInSpecificParkingLot(car, availableParkingLot);
                    ticketList.Add(ticketWhoseParking);
                }
                catch (NoPositionException e)
                {
                    return new ParkingSeveralCarsResponse()
                    {
                        TicketList = ticketList,
                        IsAllCarsParked = false,
                        Message = e.Message,
                    };
                }
                catch (WrongCarException e)
                {
                    return new ParkingSeveralCarsResponse()
                    {
                        TicketList = ticketList,
                        IsAllCarsParked = false,
                        Message = e.Message,
                    };
                }
            }

            return new ParkingSeveralCarsResponse()
            {
                TicketList = ticketList,
                IsAllCarsParked = true,
            };
        }
    }
}
