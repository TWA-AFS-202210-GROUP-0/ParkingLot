namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private const int DEFAULT_CAPACITY = 10;
        private Dictionary<Car, Guid> carInfo = new Dictionary<Car, Guid>();
        private int capacity;

        public ParkingLot()
        {
            capacity = DEFAULT_CAPACITY;
        }

        public ParkingLot(int limit)
        {
            capacity = limit;
        }

        public Ticket Park(Car car)
        {
            var newId = Guid.NewGuid();
            if (IsAtCapacity())
            {
                return null;
            }

            carInfo.Add(car, newId);
            return new Ticket()
            {
                Id = newId,
                Car = car,
            };
        }

        public List<Ticket> Park(List<Car> cars) => cars.Select(car => Park(car)).ToList();

        public Car Fetch(Ticket ticket)
        {
            if (!IsTicketValid(ticket)) { return null; }
            carInfo.Remove(ticket.Car);
            ticket.IsUsed = true;
            return ticket.Car;
        }

        private bool IsTicketValid(Ticket ticket)
        {
            return !ticket.IsUsed && ticket?.Id == carInfo[ticket?.Car];
        }

        private bool IsAtCapacity()
        {
            return carInfo.Count >= capacity;
        }
    }
}
