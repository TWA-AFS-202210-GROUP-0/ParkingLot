namespace ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkBoy
    {
        public ParkBoy()
        {
            this.ParkLots.Add(new ParkLot(10));
        }

        public List<Ticket> Tickets { get; set; } = new List<Ticket>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<ParkLot> ParkLots { get; set; } = new List<ParkLot>();

        public int CurrentParkLot { get; set; }

        public List<Ticket> ParkCar(List<Customer> customers)
        {
            int parkLotIndex = 0;
            int usedPosition = 0;
            foreach (var customer in customers)
            {
                if (parkLotIndex >= ParkLots.Count)
                {
                    throw new ParkingLotException("Not enough position.");
                }

                this.CurrentParkLot = parkLotIndex;

                if (Tickets.Any(t => t.Id == customer.CarID) || customer == null)
                {
                    continue;
                }

                // my system just gererate the ticketID === carID
                Tickets.Add(new Ticket(customer.CarID, true));
                customer.TicketID = customer.CarID;
                customer.HasTicket = true;

                usedPosition++;
                if (usedPosition >= ParkLots[parkLotIndex].Capacity)
                {
                    parkLotIndex++;

                    usedPosition = 0;
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