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
            Ticket ticket = new Ticket(car.CarID);
            parkedTicketList.Add(ticket);
            workingParkingLot.ParkCar(car);
            return ticket;
        }

        public List<Ticket> ParkSeveralCars(List<Car> carList)
        {


            var ticketList = new List<Ticket>();
            foreach (Car car in carList)
            {
                Ticket ticketWhoseParking = new Ticket(car.CarID);
                ticketList.Add(ticketWhoseParking);
                parkedTicketList.Add(ticketWhoseParking);
            }

            foreach (Car car in carList)
            {
                workingParkingLot.ParkCar(car);
            }

            return ticketList;
        }

        public Car FetchCar(Ticket ticket)
        {
            parkedTicketList.Remove(ticket);
            return workingParkingLot.FetchCar(ticket.CarID);
        }
    }
}
