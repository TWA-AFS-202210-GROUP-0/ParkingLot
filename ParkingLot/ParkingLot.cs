namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, Car> parkedCars = new Dictionary<string, Car>();

        public void ParkCar(Car car)
        {
            parkedCars.Add(car.CarID, car);
        }
        
        public Car FetchCar(string carID)
        {
            Car feachedCar = parkedCars[carID];
            parkedCars.Remove(carID);
            return feachedCar;
        }

    }



    

}
