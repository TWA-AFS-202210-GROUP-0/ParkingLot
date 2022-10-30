using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public override int SelectParkingLot()
        {
            var parkingSpaces = WorkingParkingLots.Select(e => e.GetSpaces()).ToList();
            var selectedIndex = parkingSpaces.IndexOf(parkingSpaces.Max());
            if (parkingSpaces[selectedIndex] == 0)
            {
                return -1;
            }

            return selectedIndex;
        }
    }
}
