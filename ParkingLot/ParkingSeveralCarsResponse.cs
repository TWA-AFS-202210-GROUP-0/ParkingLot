using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingSeveralCarsResponse
    {
        public List<Ticket> TicketList { get; set; }
        public bool IsAllCarsParked { get; set; }
        public string Message { get; set; }
    }
}
