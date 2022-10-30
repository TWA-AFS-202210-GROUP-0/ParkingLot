using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SingleParkingLot
    {
        private int capacity;
        public readonly Dictionary<Ticket, Car> carList;

        public SingleParkingLot(int capacity)
        {
            this.capacity = capacity;
            this.carList = new Dictionary<Ticket, Car>();
        }

        public SingleParkingLot()
        {
            this.capacity = 10;
            this.carList = new Dictionary<Ticket, Car>();
        }

        public Ticket Park(Car car)
        {
            var ticket = new Ticket();
            carList.Add(ticket, car);
            return ticket;
        }

        public bool IsNotFull()
        {
            return carList.Count < this.capacity;
        }
    }
}
