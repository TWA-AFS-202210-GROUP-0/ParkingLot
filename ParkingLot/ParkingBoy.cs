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
        public ParkingBoy(ParkingLot parkingLot)
        {
            workingParkingLot = parkingLot;
        }

        public ParkingLot WorkingParkingLot { get => workingParkingLot; set => workingParkingLot = value; }
        
        public Ticket ParkCar (Car car)
        {
            Ticket ticket = new Ticket(car.CarID);
            workingParkingLot.ParkCar(car);
            return ticket;
        }

        public List<Ticket> ParkSeveralCars(List<Car> carList)
        {
            var ticketList = (from Car car in carList
                              select new Ticket(car.CarID)).ToList();
            foreach (Car car in carList)
            {
                workingParkingLot.ParkCar(car);
            }
            return ticketList;
        }

        public Car FetchCar(Ticket ticket)
        {
            return workingParkingLot.FetchCar(ticket.CarID);
        }
    }
}
