using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Car
    {
        private int id;
        public int Id { get => id; set => id = value; }

        public Car()
        {
        }

        public Car(int carID)
        {
            this.id = carID;
        }
    }
}