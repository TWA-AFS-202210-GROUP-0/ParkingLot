using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

        public bool Have(Ticket ticket)
        {
            foreach (KeyValuePair<Ticket, Car> keyValuePair in carList)
            {
                if (keyValuePair.Key == ticket)
                {
                    return true;
                }
            }

            return false;
        }

        public Car Fetch(Ticket ticket)
        {
            foreach (KeyValuePair<Ticket, Car> keyValuePair in carList)
            {
                if (keyValuePair.Key == ticket)
                {
                    carList.Remove(keyValuePair.Key);
                    return keyValuePair.Value;
                }
            }

            return null;
        }
    }
}
