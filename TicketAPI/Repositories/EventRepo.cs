using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class EventRepo
    {
        private ssdticketsContext _context;

        public EventRepo(ssdticketsContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> Get()
        {
            return _context.Event.ToList();
        }

        public Event Get(int id)
        {
            return _context.Event.FirstOrDefault(t => t.EventId == id);
        }

    }
}
