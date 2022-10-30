using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy(List<ParkLot> lots) : base(lots)
        {
        }

        public override List<Ticket> ParkingCar(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                var availabilityMax = this.Lots.Select(lot => lot.Availability).Max();
                ParkLot carLot = this.Lots.Where(lot => lot.Availability == availabilityMax).FirstOrDefault();
                if (carLot.Availability > 0)
                {
                    this.ParkOneCar(carLot, car, carLot.Capacity - carLot.Availability + 1);
                }
                else if (carLot.Availability == 0)
                {
                    this.ParkErrorMessage = "Not enough position.";
                    Console.WriteLine(this.ParkErrorMessage);
                    return this.Tickets;
                }
            }

            return this.Tickets;
        }

        public Ticket ParkOneCar(ParkLot lot, Car car, int position)
        {
            lot.AddNewCar(car);
            Ticket ticket = new Ticket();
            ticket.CarName = car.Name;
            ticket.TicketNumber = Guid.NewGuid().ToString();
            ticket.Position = position;
            this.Tickets.Add(ticket);
            return ticket;
        }

        public override List<string> FetchCar(List<Ticket> tickets)
        {
            List<string> cars = new List<string>();
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

            return cars;
        }

        public override string FetchOneCar(Ticket ticket)
        {
            if (ticket != null)
            {
                foreach (ParkLot lot in this.Lots)
                {
                    foreach (Car car in lot.Cars)
                    {
                        if (car.Name == ticket.CarName)
                        {
                            return ticket.CarName;
                        }
                    }
                }

                throw new ParkingLotException("Unrecognized parking ticket.");
            }

            throw new ParkingLotException("Please provide your parking ticket.");
        }
    }
}
