using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Customer
    {
        public Customer(int carID)
        {
            this.CarID = carID;
        }

        public int CarID { get; set; }
        public int TicketID { get; set; }
        public bool HasTicket { get; set; }
    }
}