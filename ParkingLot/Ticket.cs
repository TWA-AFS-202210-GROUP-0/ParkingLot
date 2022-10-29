using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        private string carID;
        public Ticket(string carID)
        {
            this.carID = carID;
        }
        public string CarID { get => carID; }
    }
}
