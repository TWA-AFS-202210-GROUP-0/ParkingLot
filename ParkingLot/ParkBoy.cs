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
            this.Customers = customers;
            foreach (var customer in customers)
            {
                // my system gererate the ticketID === carID
                Tickets.Add(new Ticket(customer.CarID, true));
                customer.TicketID = customer.CarID;
                customer.HasTicket = true;
                if (Tickets.Count >= ParkLotCapacity)
                {
                    break;
                }
            }

            return Tickets;
        }

        public bool FetchCar(Customer customer)
        {
            try
            {
                var ticket = Tickets.Single(t => t.Id == customer.CarID);
                return ticket.IsValid;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}