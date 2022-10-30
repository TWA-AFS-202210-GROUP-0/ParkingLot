using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        // using the carID
        private int id;

        public Ticket(int id)
        {
            this.id = id;
        }

        public int Id { get => id; set => id = value; }
    }
}