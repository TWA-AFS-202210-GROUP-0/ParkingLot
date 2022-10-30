using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Customer
    {
        private int carID;

        public Customer(int id)
        {
            this.carID = id;
        }

        public int CarID { get => carID; set => carID = value; }
    }
}