using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class SmartParkingBoy : ParkingBoy
    {
        public SmartParkingBoy() : base()
        {
            this.SingleParkingLots = new List<SingleParkingLot>();
        }

        public override Ticket Park(Car car)
        {
            int indexOfMostEmptySingleParkingLot = 0;
            for (int i = 0; i < SingleParkingLots.Count; i++)
            {
                if (this.SingleParkingLots[i].GetRemainPosition() > SingleParkingLots[indexOfMostEmptySingleParkingLot].GetRemainPosition())
                {
                    indexOfMostEmptySingleParkingLot = i;
                }
            }

            if (SingleParkingLots[indexOfMostEmptySingleParkingLot].IsNotFull())
            {
                var ticket = SingleParkingLots[indexOfMostEmptySingleParkingLot].Park(car);
                return ticket;
            }

            throw new ExpectedException("Not enough position.");
        }

        private SingleParkingLot FindMostEmptySingleParkingLot(List<SingleParkingLot> singleParkingLots)
        {
            SingleParkingLot mostEmptySingleParkingLot = singleParkingLots.First();
            for (int i = 0; i < singleParkingLots.Count; i++)
            {
                if (this.SingleParkingLots[i].GetRemainPosition() > mostEmptySingleParkingLot.GetRemainPosition())
                {
                    mostEmptySingleParkingLot = singleParkingLots[i];
                }
            }

            return mostEmptySingleParkingLot;
        }
    }
}
