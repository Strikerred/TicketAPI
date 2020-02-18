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
    }
}
