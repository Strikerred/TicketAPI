using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.ResponseModels
{
    public class SeatResponse
    {
        public int SeatId { get; set; }
        public decimal? Price { get; set; }
        public int? RowId { get; set; }
        public string SectionName { get; set; }
    }
}
