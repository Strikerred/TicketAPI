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

        public EventSeat Get(int id)
        {
            return _context.EventSeat.FirstOrDefault(t => t.EventSeatId == id);
        }

        public IEnumerable<EventSeat> GetAll(int id)
        {
            return _context.EventSeat.Where(t => t.EventId == id);
        }
    }
}
