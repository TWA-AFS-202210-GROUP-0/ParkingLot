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
        private List<Ticket> parkedTicketList= new List<Ticket>();
        public ParkingBoy(ParkingLot parkingLot)
        {
            workingParkingLot = parkingLot;
        }

        public ParkingLot WorkingParkingLot { get => workingParkingLot; set => workingParkingLot = value; }
        
        public Ticket ParkCar (Car car)
        {
            if (car == null)
            {
                throw new WrongCarException();
            }
            workingParkingLot.ParkCar(car);
            Ticket ticket = new Ticket(car.CarID);
            parkedTicketList.Add(ticket);
            return ticket;
        }

        public List<Ticket> ParkSeveralCars(List<Car> carList)
        {


            var ticketList = new List<Ticket>();
            foreach (Car car in carList)
            {
                try
                {
                    if (car == null)
                    {
                        throw new WrongCarException();
                    }

                    workingParkingLot.ParkCar(car);
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

        public Car FetchCar(Ticket ticket)
        {
            CheckValidTicket(ticket);
            parkedTicketList.Remove(ticket);
            return workingParkingLot.FetchCar(ticket.CarID);
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
