using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private const string PARKINGLOT1 = "ParkingLot1";
        private const string PARKINGLOT2 = "ParkingLot2";

        public ParkingBoy()
        {
            ParkingLot1 = new ParkingLot(PARKINGLOT1);
            ParkingLot2 = new ParkingLot(PARKINGLOT2);
        }

        public ParkingBoy(int lot1Limit, int lot2Limit)
        {
            ParkingLot1 = new ParkingLot(PARKINGLOT1, lot1Limit);
            ParkingLot2 = new ParkingLot(PARKINGLOT2, lot2Limit);
        }

        public ParkingLot ParkingLot1 { get; set; }
        public ParkingLot ParkingLot2 { get; set; }

        public virtual Ticket Park(Car car)
        {
            if (ParkingLot1.IsAtCapacity())
            {
                return ParkingLot2.BeParked(car);
            }

            if (ParkingLot2.IsAtCapacity())
            {
                return null;
            }

            return ParkingLot1.BeParked(car);
        }

        public List<Ticket> Park(List<Car> cars) => cars.Select(car => Park(car)).ToList();

        public Car Fetch(Ticket ticket)
        {
            if (ticket == null)
            {
                return ParkingLot1.BeFetched(ticket);
            }

            if (ticket.ParkingLot == PARKINGLOT1)
            {
                return ParkingLot1.BeFetched(ticket);
            }
            else if (ticket.ParkingLot == PARKINGLOT2)
            {
                return ParkingLot2.BeFetched(ticket);
            }

            return null;
        }
    }
}
