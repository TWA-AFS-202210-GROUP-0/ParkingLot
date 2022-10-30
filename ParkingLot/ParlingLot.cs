using System;
using System.Collections.Generic;

namespace ParkingLot
{
    public class ParkLot
    {
        public ParkLot(int capacity)
        {
            Cars = new List<Car>();
            this.Capacity = capacity;
            this.Availability = this.Capacity;
        }

        public List<Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Availability { get; set; }
        public void AddNewCar(Car car)
        {
            this.Cars.Add(car);
            this.Availability -= 1;
        }
    }
}
