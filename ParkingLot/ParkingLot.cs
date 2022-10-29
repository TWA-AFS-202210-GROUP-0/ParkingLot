namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, Car> parkedCars = new Dictionary<string, Car>();
        private int parkingCapicity;

        public ParkingLot(int parkingCapicity = 10)
        { 
            this.parkingCapicity = parkingCapicity;
        }

        public void ParkCar(Car car)
        {
            CheckCapicity();
            parkedCars.Add(car.CarID, car);
        }

        private void CheckCapicity()
        {
            if (parkingCapicity - parkedCars.Count == 0)
            {
                throw new NoPositionException();
            }
        }

        public Car FetchCar(string carID)
        {
            Car feachedCar = parkedCars[carID];
            parkedCars.Remove(carID);
            return feachedCar;
        }

    }



    

}
