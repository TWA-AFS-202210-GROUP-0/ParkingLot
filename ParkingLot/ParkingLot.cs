namespace ParkingLot
{
    using System;
    using System.Collections.Generic;

    public class ParkingLot
    {
        private Dictionary<string, Car> parkedCars = new Dictionary<string, Car>();

        public Ticket ParkCar(Car car)
        {
            Ticket ticket = new Ticket(car.CarID);
            parkedCars.Add(car.CarID, car);
            return ticket;
        }
        
        public Car FetchCar(Ticket ticket)
        {
            Car feachedCar = parkedCars[ticket.CarID];
            parkedCars.Remove(ticket.CarID);
            return feachedCar;
        }

    }



    

}
