using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public interface IParkingBoy
    {
        public int SelectParkingLot();
        public string ParkCar(Car car);
        public ParkingCarsRespone ParkCars(List<Car> car);
        public Car FetchCar(string ticket);
    }
}
