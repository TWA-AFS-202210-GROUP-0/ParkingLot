using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class NoPositionException : Exception
    {
        public NoPositionException(string message) : base(message)
        {
        }
    }
}
