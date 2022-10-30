﻿using System.Buffers;
using System.Collections.Generic;

namespace ParkingLot
{
    using System;
    public class ParkingLot
    {
        public int Capacity { get; init; } = 10;
        public List<Car> ParkedCars { get; set; }
        public List<string> TicketCopies { get; set; }

        public int GetSpaces()
        {
            return Capacity - ParkedCars.Count;
        }
    }
}
