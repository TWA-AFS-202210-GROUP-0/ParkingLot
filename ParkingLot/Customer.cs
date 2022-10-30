using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Customer
    {
        public string Name { get; init; }

        public Car Car { get; set; }

        public string Ticket { get; set; } = null;

        public void HandOverCar()
        {
            Ticket = string.Empty;
        }

        public Car ShowTicketGetCar()
        {
            return new Car();
        }

        public bool isMyCar(string vehicleId)
        {
            return vehicleId == this.Car.VehicleId;
        }
    }
}
