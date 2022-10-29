using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private ParkingLot workingParkingLot;
        public ParkingBoy(ParkingLot parkingLot)
        {
            workingParkingLot = parkingLot;
        }

        public ParkingLot WorkingParkingLot { get => workingParkingLot; set => workingParkingLot = value; }
        
        public Ticket ParkCar (Car car)
        {
            return workingParkingLot.ParkCar(car);
        }

        public Car FetchCar(Ticket ticket)
        {
            return workingParkingLot.FetchCar(ticket);
        }
    }
}
