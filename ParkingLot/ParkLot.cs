using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkLot
    {
        public ParkLot(int capacity)
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; } = 10;
    }
}