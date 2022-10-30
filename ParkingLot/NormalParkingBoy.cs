using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class NormalParkingBoy
    {
        public string ParkCar(Car car)
        {
            return Guid.NewGuid().ToString();
        }

        public List<string> ParkCars(List<Car> cars)
        {
            return new List<string>();
        }
    }
}
