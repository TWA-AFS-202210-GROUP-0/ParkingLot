using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot parkingLot1;
        private ParkingLot parkingLot2;

        public ParkingBoy()
        {
            parkingLot1 = new ParkingLot("ParkingLot1");
            parkingLot2 = new ParkingLot("ParkingLot2");
        }

        public ParkingBoy(int lot1Limit, int lot2Limit)
        {
            parkingLot1 = new ParkingLot("ParkingLot1", lot1Limit);
            parkingLot2 = new ParkingLot("ParkingLot2", lot2Limit);
        }

        public Ticket Park(Car car)
        {
            if (parkingLot1.IsAtCapacity())
            {
                return parkingLot2.BeParked(car);
            }
            return parkingLot1.BeParked(car);
        }

        public List<Ticket> Park(List<Car> car)
        {
            return null;
        }

        public Car Fetch(Ticket ticket)
        {
            return null;
        }
    }
}
