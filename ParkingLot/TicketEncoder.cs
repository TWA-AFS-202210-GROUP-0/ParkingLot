using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class TicketEncoder
    {
        private const string ContextSplitter = "_context_splitter_";

        public static string Encoder(string ticket, int numberOfParkingLot)
        {
            return $"{numberOfParkingLot}{ContextSplitter}{ticket}";
        }

        public static (int, string) Decoder(string ticket)
        {
            try
            {
                var decodedTicked = ticket.Split(ContextSplitter);

                return (int.Parse(decodedTicked[0]), ticket.Split(ContextSplitter)[1]);
            }
            catch (Exception e)
            {
                throw new Exception("Unrecognized parking ticket");
            }
        }
    }
}
