using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        private string carID;
        public Car(string carID)
        {
            this.carID = carID;
        }

        public string CarID { get => carID; }
    }
}
