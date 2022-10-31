using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class NormalParkingBoy : ParkingBoy
    {
        public override int SelectParkingLot()
        {
            return WorkingParkingLots.FindIndex(e => e.GetSpaces() > 0);
        }
    }
}
