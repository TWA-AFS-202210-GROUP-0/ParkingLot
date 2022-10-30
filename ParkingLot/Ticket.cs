using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class Ticket
    {
        public Ticket(int id, bool isValid)
        {
            this.Id = id;
            this.IsValid = isValid;
        }

        public int Id { get; set; }
        public bool IsValid { get; set; }
    }
}