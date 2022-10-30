namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkBoy
    {
        public ParkBoy()
        {
        }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public int ParkLotCapacity { get; set; } = 10;

        public List<Ticket> ParkCar(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                if (Tickets.Any(t => t.Id == customer.CarID) || customer == null)
                {
                    continue;
                }

                // my system just gererate the ticketID === carID
                Tickets.Add(new Ticket(customer.CarID, true));
                customer.TicketID = customer.CarID;
                customer.HasTicket = true;

                if (Tickets.Count >= ParkLotCapacity)
                {
                    throw new ParkingLotException("Not enough position.");
                }
            }

            this.Customers = customers;
            return Tickets;
        }

        public bool FetchCar(Customer customer)
        {
            if (!customer.HasTicket)
            {
                throw new ParkingLotException("Please provide your parking ticket.");
            }

            if (!Tickets.Any(t => t.Id == customer.TicketID))
            {
                throw new ParkingLotException("Unrecognized parking ticket.");
            }

            var ticket = Tickets.Single(t => t.Id == customer.TicketID);
            if (!ticket.IsValid)
            {
                throw new ParkingLotException("Unrecognized parking ticket.");
            }

            return true;
        }
    }
}