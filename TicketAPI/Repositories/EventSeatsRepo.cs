using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class EventSeatsRepo
    {
        private ssdticketsContext _context;

        public EventSeatsRepo(ssdticketsContext context)
        {
            _context = context;
        }

        public async Task<EventSeat> Get(int id)
        {
            return await _context.EventSeat.FirstOrDefaultAsync(t => t.EventSeatId == id);
        }

        public async Task<IEnumerable<EventSeat>> GetAll(int id)
        {
            return await _context.EventSeat.Where(t => t.EventId == id).ToListAsync();
        }
    }
}
