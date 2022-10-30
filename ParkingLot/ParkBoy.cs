namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkBoy
    {
        private List<Car> cars = new List<Car>();

        public ParkBoy(List<Car> cars)
        {
            this.cars = cars;
        }

        public List<Car> Cars { get => cars; set => cars = value; }

        public List<Ticket> ParkCar()
        {
            List<Ticket> tickets = this.cars.Select(c => new Ticket(c.Id)).ToList();
            return tickets;
        }
    }
}