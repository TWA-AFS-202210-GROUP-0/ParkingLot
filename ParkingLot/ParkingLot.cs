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

        public Car Fetch(Ticket ticket)
        {
            this.parkedCars.Remove(ticket.Car);
            return ticket.Car;
        }
    }
}
