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
        protected List<SingleParkingLot> SingleParkingLots { get; set; }

        public ParkingBoy()
        {
            this.SingleParkingLots = new List<SingleParkingLot>();
        }

        public void Manage(SingleParkingLot singleParkingLot)
        {
            this.SingleParkingLots.Add(singleParkingLot);
        }

        public virtual Ticket Park(Car car)
        {
            for (int i = 0; i < SingleParkingLots.Count; i++)
            {
                if (SingleParkingLots[i].IsNotFull())
                {
                    var ticket = SingleParkingLots[i].Park(car);
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
            for (int i = 0; i < SingleParkingLots.Count; i++)
            {
                var singleParkingLot = SingleParkingLots[i];
                if (singleParkingLot.Have(ticket))
                {
                    return true;
                }
            }

            return false;
        }

        private Car FetchCar(Ticket ticket)
        {
            for (int i = 0; i < SingleParkingLots.Count; i++)
            {
                var singleParkingLot = SingleParkingLots[i];
                if (singleParkingLot.Have(ticket))
                {
                    return singleParkingLot.Fetch(ticket);
                }
            }

            return null;
        }
    }
}
