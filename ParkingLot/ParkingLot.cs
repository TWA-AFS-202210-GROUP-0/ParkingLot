namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        private Dictionary<string, Car> parkedCars = new Dictionary<string, Car>();
        private int parkingCapicity;

        public ParkingLot(int parkingCapicity = 10)
        { 
            this.parkingCapicity = parkingCapicity;
        }

        public virtual void ParkCar(Car car)
        {
            CheckValidCar(car);
            CheckCapicity();
            parkedCars.Add(car.CarID, car);
        }

        private void CheckValidCar(Car car)
        {
            if (HasCar(car.CarID))
            {
                throw new WrongCarException();
            }
        }

        public bool HasCar(string carID)
        {
            return parkedCars.Keys.Contains(carID);
        }

        private void CheckCapicity()
        {
            if (IsFull())
            {
                throw new NoPositionException("Not enough position.");
            }
        }

        public bool IsFull()
        {
            return parkingCapicity - parkedCars.Count == 0;
        }

        public Car FetchCar(string carID)
        {
            Car feachedCar = parkedCars[carID];
            parkedCars.Remove(carID);
            return feachedCar;
        }

    }



    

}
