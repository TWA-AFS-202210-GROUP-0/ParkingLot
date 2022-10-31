using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingLotException : Exception
    {
        public ParkingLotException(string message) : base(message)
        {
        }
    }
}
