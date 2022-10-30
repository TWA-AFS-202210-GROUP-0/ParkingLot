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
        private ParkingLot parkingLot1;
        private ParkingLot parkingLot2;

        public ParkingBoy()
        {
            parkingLot1 = new ParkingLot(PARKINGLOT1);
            parkingLot2 = new ParkingLot(PARKINGLOT2);
        }

        public ParkingBoy(int lot1Limit, int lot2Limit)
        {
            parkingLot1 = new ParkingLot(PARKINGLOT1, lot1Limit);
            parkingLot2 = new ParkingLot(PARKINGLOT2, lot2Limit);
        }

        public Ticket Park(Car car)
        {
            if (parkingLot1.IsAtCapacity())
            {
                return parkingLot2.BeParked(car);
            }

            if (parkingLot2.IsAtCapacity())
            {
                return null;
            }

            return parkingLot1.BeParked(car);
        }

        public List<Ticket> Park(List<Car> cars) => cars.Select(car => Park(car)).ToList();

        public Car Fetch(Ticket ticket)
        {
            if (ticket.ParkingLot == PARKINGLOT1)
            {
                return parkingLot1.BeFetched(ticket);
            }
            else if (ticket.ParkingLot == PARKINGLOT2)
            {
                return parkingLot2.BeFetched(ticket);
            }

            return null;
        }
    }
}
