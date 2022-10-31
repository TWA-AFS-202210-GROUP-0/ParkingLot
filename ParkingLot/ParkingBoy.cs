using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot workingParkingLot;
        private List<Ticket> parkedTicketList = new List<Ticket>();
        private List<ParkingLot> workingParkingLots = new List<ParkingLot>();

        public ParkingBoy(ParkingLot parkingLot)
        {
            this.workingParkingLots.Add(parkingLot);
        }

        public ParkingBoy(List<ParkingLot> workingParkingLots)
        {
            this.workingParkingLots = workingParkingLots;
        }

        public ParkingLot WorkingParkingLot { get => workingParkingLot; set => workingParkingLot = value; }
        public List<ParkingLot> WorkingParkingLots { get => workingParkingLots; set => workingParkingLots = value; }

        public virtual Ticket ParkCar (Car car)
        {
            CheckNotNullCar(car);

            ParkingLot availableParkingLot = workingParkingLots.FirstOrDefault(parkingLot => !parkingLot.IsFull());
            if (availableParkingLot == null)
            {
                throw new NoPositionException("Not enough position.");
            }

            return ParkCarInSpecificParkingLot(car, availableParkingLot);
        }

        protected static void CheckNotNullCar(Car car)
        {
            if (car == null)
            {
                throw new WrongCarException();
            }
        }

        public virtual ParkingSeveralCarsResponse ParkSeveralCars(List<Car> carList)
        {
            var ticketList = new List<Ticket>();
            foreach (Car car in carList)
            {
                try
                {
                    CheckNotNullCar(car);
                    ParkingLot availableParkingLot = workingParkingLots.FirstOrDefault(parkingLot => !parkingLot.IsFull());
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

        protected Ticket ParkCarInSpecificParkingLot(Car car, ParkingLot availableParkingLot)
        {
            availableParkingLot.ParkCar(car);
            Ticket ticketWhoseParking = new Ticket(car.CarID);
            parkedTicketList.Add(ticketWhoseParking);
            return ticketWhoseParking;
        }

        public Car FetchCar(Ticket ticket)
        {
            CheckValidTicket(ticket);
            parkedTicketList.Remove(ticket);
            ParkingLot parkedLot = workingParkingLots.FirstOrDefault(parkingLot => parkingLot.HasCar(ticket.CarID));
            return parkedLot.FetchCar(ticket.CarID);
        }

        private void CheckValidTicket(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new NoTicketException("Please provide your parking ticket.");
            }

            if (!parkedTicketList.Contains(ticket))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }
        }
    }
}
