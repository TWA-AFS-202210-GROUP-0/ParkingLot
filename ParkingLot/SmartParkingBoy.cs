using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy() : base()
        {
        }

        public SmartParkingBoy(int lot1Limit, int lot2Limit) : base(lot1Limit, lot2Limit)
        {
        }

        public override Ticket Park(Car car)
        {
            if (IsParkedInLot1())
            {
                return ParkingLot1.BeParked(car);
            }

            return ParkingLot2.BeParked(car);
        }

        public bool IsParkedInLot1()
        {
            return ParkingLot1.GetEmptyPositionNumber() >= ParkingLot2.GetEmptyPositionNumber();
        }
    }
}
