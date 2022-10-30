namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<Car, Guid> carInfo = new Dictionary<Car, Guid>();

        public Ticket Park(Car car)
        {
            var newId = Guid.NewGuid();
            carInfo.Add(car, newId);
            return new Ticket()
            {
                Id = newId,
                Car = car,
            };
        }

        public List<Ticket> Park(List<Car> cars)
        {
            var tickets = new List<Ticket>();
            foreach (var car in cars)
            {
                var newId = Guid.NewGuid();
                carInfo.Add(car, newId);
                tickets.Add(new Ticket() { Car = car });
            }

            return tickets;
        }

        public Car Fetch(Ticket ticket)
        {
            if (!ValidateTicket(ticket)) { return null; }
            this.carInfo.Remove(ticket.Car);
            return ticket.Car;
        }

        private bool ValidateTicket(Ticket ticket)
        {
            return ticket?.Id == carInfo[ticket?.Car];
        }
    }
}
