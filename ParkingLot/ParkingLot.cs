namespace ParkingLot
{
    using System;
    public class ParkingLot
    {
        public Lazy<Car> ParkedCars { get; set; }

        public Ticket Park(Car car)
        {
            return new Ticket()
            {
                Owner = car.Owner,
                Name = car.Name,
            };
        }
    }
}
