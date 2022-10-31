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

        public string HandOverCar(IParkingBoy parkingBoy)
        {
            try
            {
                this.Ticket = parkingBoy.ParkCar(this.Car);
                return $"Parked car with ticket = {this.Ticket}";
            }
            catch (Exception ex)
            { return ex.Message; }
        }

        public string ShowTicketGetCar(IParkingBoy parkingBoy)
        {
            try
            {
                var fetchedCar = parkingBoy.FetchCar(this.Ticket);
                if (fetchedCar.VehicleId != this.Car.VehicleId)
                {
                    throw new Exception("Fetched wrong car");
                }

                return "Fetched my car";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
