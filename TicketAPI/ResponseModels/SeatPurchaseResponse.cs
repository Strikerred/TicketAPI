using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.ResponseModels
{
    public class SeatPurchaseResponse
    {
        public int PurchaseId { get; set; }
        public int EventSeatId { get; set; }
        public decimal? SeatSubtotal { get; set; }
    }
}
