namespace ParkingLot
{
    using System;
    public class Ticket
    {
        public Guid Id { get; set; }
        public Car Car { get; set; }
        public bool IsUsed { get; set; }
    }
}
