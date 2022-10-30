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

            availableParkingLot.ParkCar(car);
            Ticket ticket = new Ticket(car.CarID);
            parkedTicketList.Add(ticket);
            return ticket;
        }

        protected static void CheckNotNullCar(Car car)
        {
            if (car == null)
            {
                throw new WrongCarException();
            }
        }

        public virtual List<Ticket> ParkSeveralCars(List<Car> carList)
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

                    availableParkingLot.ParkCar(car);
                    Ticket ticketWhoseParking = new Ticket(car.CarID);
                    parkedTicketList.Add(ticketWhoseParking);
                    ticketList.Add(ticketWhoseParking);
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
