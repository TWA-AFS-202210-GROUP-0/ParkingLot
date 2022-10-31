using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public abstract class ParkingBoy : IParkingBoy
    {
        public List<ParkingLot> WorkingParkingLots { get; set; }

        public abstract int SelectParkingLot();

        public string ParkCar(Car car)
        {
            var parkingLotIndex = SelectParkingLot();
            if (parkingLotIndex == -1)
            {
                throw new Exception("Not enough position");
            }

            return ParkCarIntoSelectedParkingLot(car, parkingLotIndex);
        }

        public string ParkCarIntoSelectedParkingLot(Car car, int parkingLotIndex)
        {
            var ticketGuid = Guid.NewGuid().ToString();
            var ticket = TicketEncoder.Encoder(ticketGuid, parkingLotIndex);
            WorkingParkingLots[parkingLotIndex].ParkedCars.Add(car);
            WorkingParkingLots[parkingLotIndex].TicketCopies.Add(ticket);
            return ticket;
        }

        public ParkingCarsRespone ParkCars(List<Car> cars)
        {
            var tickets = new List<string>();
            foreach (var car in cars)
            {
                try
                {
                    var ticket = this.ParkCar(car);
                    tickets.Add(ticket);
                }
                catch (Exception e)
                {
                    return new ParkingCarsRespone()
                    {
                        Tickets = tickets,
                        IsAllCarsParked = false,
                        Message = e.Message,
                    };
                }
            }

            return new ParkingCarsRespone()
            {
                Tickets = tickets,
                IsAllCarsParked = true,
            };
        }

        public Car FetchCar(string ticket)
        {
            if (ticket == null || ticket == string.Empty)
            {
                throw new Exception("Please provide ticket");
            }

            try
            {
                var (numberOfParkingLot, ticketGuid) = TicketEncoder.Decoder(ticket);
                var carIndex = WorkingParkingLots[numberOfParkingLot].TicketCopies.FindIndex(e => e == ticketGuid);
                if (carIndex == -1)
                {
                    throw new Exception("Unrecognized parking ticket");
                }

                var car = WorkingParkingLots[numberOfParkingLot].ParkedCars[carIndex];
                WorkingParkingLots[numberOfParkingLot].ParkedCars.RemoveAt(carIndex);
                WorkingParkingLots[numberOfParkingLot].TicketCopies.RemoveAt(carIndex);

                return car;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
