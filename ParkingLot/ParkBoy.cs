namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkBoy
    {
        private List<Customer> customers = new List<Customer>();
        private List<Ticket> tickets = new List<Ticket>();

        public ParkBoy()
        {
        }

        public List<Customer> Customers { get => customers; set => customers = value; }

        public List<Ticket> ParkCar(List<Customer> customers)
        {
            this.Customers = customers;
            List<Ticket> newTickets = new List<Ticket>();
            foreach (var customer in customers)
            {
                newTickets.Add(new Ticket(customer.CarID));
                customer.TicketID = customer.CarID;
                customer.HasTicket = true;
            }

            this.tickets = newTickets;
            return tickets;
        }

        public bool FetchCar(Customer customer)
        {
            if (tickets.Any(s => s.Id == customer.CarID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}