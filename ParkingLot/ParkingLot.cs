namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private List<Car> parkedCars = new List<Car>();

        public Ticket Park(Car car)
        {
            parkedCars.Add(car);
            return new Ticket()
            {
                Car = car,
            };
        }

        public List<Ticket> Park(List<Car> cars)
        {
            var tickets = new List<Ticket>();
            foreach (var car in cars)
            {
                parkedCars.Add(car);
                tickets.Add(new Ticket() { Car = car });
            }

            return tickets;
        }

        public Car Fetch(Ticket ticket)
        {
            this.parkedCars.Remove(ticket.Car);
            return ticket.Car;
        }
    }
}
