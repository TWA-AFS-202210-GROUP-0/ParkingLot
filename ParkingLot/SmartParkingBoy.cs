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

            availableParkingLot.ParkCar(car);
            Ticket ticket = new Ticket(car.CarID);
            parkedTicketList.Add(ticket);
            return ticket;
        }

        public override List<Ticket> ParkSeveralCars(List<Car> carList)
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

                    availableParkingLot.ParkCar(car);
                    Ticket ticketWhoseParking = new Ticket(car.CarID);
                    ticketList.Add(ticketWhoseParking);
                    parkedTicketList.Add(ticketWhoseParking);
                }
                catch (NoPositionException e)
                {
                    ticketList.Add(null);
                }
                catch (WrongCarException e)
                {
                    ticketList.Add(null);
                }
            }

            return ticketList;
        }
    }
}
