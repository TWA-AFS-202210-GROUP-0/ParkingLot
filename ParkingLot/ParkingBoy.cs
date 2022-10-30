using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class ParkingBoy
    {
        private readonly List<SingleParkingLot> singleParkingLots = new List<SingleParkingLot>();

        public ParkingBoy()
        {
            this.singleParkingLots = new List<SingleParkingLot>();
        }

        public void Manage(SingleParkingLot singleParkingLot)
        {
            this.singleParkingLots.Add(singleParkingLot);
        }

        public Ticket Park(Car car)
        {
            for (int i = 0; i < singleParkingLots.Count; i++)
            {
                if (singleParkingLots[i].IsNotFull())
                {
                    var ticket = singleParkingLots[i].Park(car);
                    return ticket;
                }
            }

            return null;
        }
    }
}
