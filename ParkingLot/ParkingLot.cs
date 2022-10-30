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
        private string name;

        public ParkingLot(string name)
        {
            this.name = name;
            capacity = DEFAULT_CAPACITY;
        }

        public ParkingLot(string name, int limit)
        {
            this.name = name;
            capacity = limit;
        }

        public Ticket BeParked(Car car)
        {
            var newId = Guid.NewGuid();
            if (IsAtCapacity())
            {
                throw new Exception("Not enough position.");
            }

            carInfo.Add(car, newId);
            return new Ticket()
            {
                Id = newId,
                Car = car,
                ParkingLot = name,
            };
        }

        public List<Ticket> BeParked(List<Car> cars) => cars.Select(car => BeParked(car)).ToList();

        public Car BeFetched(Ticket ticket)
        {
            if (ticket == null) { throw new Exception("Please provide your parking ticket."); }
            if (!IsTicketValid(ticket)) { throw new Exception("Unrecognized parking ticket."); }
            carInfo.Remove(ticket.Car);
            ticket.IsUsed = true;
            return ticket.Car;
        }

        public bool IsAtCapacity()
        {
            return carInfo.Count >= capacity;
        }

        public int GetEmptyPositionNumber()
        {
            return capacity - carInfo.Count;
        }

        private bool IsTicketValid(Ticket ticket)
        {
            return !ticket.IsUsed && ticket?.Id == carInfo[ticket?.Car];
        }
    }
}
