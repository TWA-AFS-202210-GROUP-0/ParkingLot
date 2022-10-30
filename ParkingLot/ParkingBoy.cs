using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public ParkingBoy(ParkLot lot)
        {
            this.Tickets = new List<Ticket>();
            this.Lot = lot;
        }

        public ParkLot Lot { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Ticket ParkingCar(Car car)
        {
            this.Lot.AddNewCar(car);
            Ticket ticket = new Ticket();
            ticket.CarName = car.Name;
            ticket.TicketNumber = Guid.NewGuid().ToString();
            ticket.Position = 1;
            this.Tickets.Add(ticket);
            return ticket;
        }

        public string FetchCar(Ticket ticket)
        {
            if (this.Lot.Availability != this.Lot.Capacity)
            {
                foreach (Car car in this.Lot.Cars)
                {
                    if (car.Name == ticket.CarName)
                    {
                        return car.Name;
                    }
                }
            }

            return string.Empty;
        }
    }
}
