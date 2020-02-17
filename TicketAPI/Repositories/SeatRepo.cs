using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class SeatRepo
    {
        private readonly TicketsDBContext _context;

        public SeatRepo(TicketsDBContext context)
        {
            _context = context;
        }
        public Seat GetSeat(long id)
        {
            return _context.Seat.Where(s => s.SeatId == id).FirstOrDefault();
        }
    }
}
