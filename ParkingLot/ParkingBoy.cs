using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        public ParkingBoy(List<ParkLot> lots)
        {
            this.Tickets = new List<Ticket>();
            this.Lot = new ParkLot(0);
            this.Lots = lots;
            for (int indexLot = 0; indexLot < this.Lots.Count; indexLot++)
            {
                this.Lot.Capacity += this.Lots[indexLot].Capacity;
                this.Lot.Availability += this.Lots[indexLot].Availability;
            }
        }

        public ParkLot Lot { get; set; }
        public List<ParkLot> Lots { get; set; }
        public string ParkErrorMessage { get; set; }
        public string FetchErrorMessage { get; set; }
        public List<Ticket> Tickets { get; set; }
        public virtual List<Ticket> ParkingCar(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                if (this.Lot.Availability > 0)
                {
                    this.ParkOneCar(car, this.Lot.Capacity - this.Lot.Availability + 1);
                }
                else if (this.Lot.Availability == 0)
                {
                    this.ParkErrorMessage = "Not enough position.";
                    Console.WriteLine(this.ParkErrorMessage);
                    return this.Tickets;
                }
            }

            return this.Tickets;
        }

        public Ticket ParkOneCar(Car car, int position)
        {
            this.Lot.AddNewCar(car);
            Ticket ticket = new Ticket();
            ticket.CarName = car.Name;
            ticket.TicketNumber = Guid.NewGuid().ToString();
            ticket.Position = position;
            this.Tickets.Add(ticket);
            return ticket;
        }

        public virtual List<string> FetchCar(List<Ticket> tickets)
        {
            List<string> cars = new List<string>();
            if (this.Lot.Availability != this.Lot.Capacity)
            {
               foreach (Ticket ticket in tickets)
                {
                    try
                    {
                        cars.Add(this.FetchOneCar(ticket));
                    }
                    catch (ParkingLotException e)
                    {
                        this.FetchErrorMessage += e.Message;
                        continue;
                    }
                }
            }

            return cars;
        }

        public virtual string FetchOneCar(Ticket ticket)
        {
            if (ticket != null)
            {
                foreach (var car in this.Lot.Cars.Where(car => car.Name == ticket.CarName))
                {
                    return car.Name;
                }

                throw new ParkingLotException("Unrecognized parking ticket.");
            }

            throw new ParkingLotException("Please provide your parking ticket.");
        }
    }
}
