using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.ResponseModels
{
    public class EventSeatResponse
    {
        public int EventSeatId { get; set; }
        public int SeatId { get; set; }
        public int EventId { get; set; }
        public decimal? EventSeatPrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
