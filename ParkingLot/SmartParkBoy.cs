using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkBoy : ParkBoy
    {
        public override List<Ticket> ParkCar(List<Customer> customers)
        {
            ParkLots = ParkLots.OrderByDescending(p => p.Capacity).ToList();
            return base.ParkCar(customers);
        }
    }
}