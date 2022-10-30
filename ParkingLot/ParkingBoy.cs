using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly List<SingleParkingLot> singleParkingLots = new List<SingleParkingLot>();

        public ParkingBoy()
        {
            this.singleParkingLots = new List<SingleParkingLot>();
        }

        public void Manage(SingleParkingLot singleParkingLot)
        {
            this.singleParkingLots.Add(singleParkingLot);
        }

        public Ticket Park(Car car)
        {
            for (int i = 0; i < singleParkingLots.Count; i++)
            {
                if (singleParkingLots[i].IsNotFull())
                {
                    var ticket = singleParkingLots[i].Park(car);
                    return ticket;
                }
            }

            throw new ExpectedException("Not enough position.");
        }

        public Car Fetch(Ticket ticket)
        {
            if (!ContainCar(ticket))
            {
                throw new ExpectedException("Unrecognized parking ticket.");
            }

            return FetchCar(ticket);
        }

        public Car Fetch()
        {
            throw new ExpectedException("Please provide your parking ticket.");
        }

        public List<Ticket> ParkSeveral(List<Car> cars)
        {
            var tickets = new List<Ticket>();
            foreach (var car in cars)
            {
                tickets.Add(Park(car));
            }

            return tickets;
        }

        private bool ContainCar(Ticket ticket)
        {
            for (int i = 0; i < singleParkingLots.Count; i++)
            {
                var singleParkingLot = singleParkingLots[i];
                if (singleParkingLot.Have(ticket))
                {
                    return true;
                }
            }

            return false;
        }

        private Car FetchCar(Ticket ticket)
        {
            for (int i = 0; i < singleParkingLots.Count; i++)
            {
                var singleParkingLot = singleParkingLots[i];
                if (singleParkingLot.Have(ticket))
                {
                    return singleParkingLot.Fetch(ticket);
                }
            }

            return null;
        }
    }
}
