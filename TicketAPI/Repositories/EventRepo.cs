using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Interfaces;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class EventRepo: IEventRepo
    {
        private ssdticketsContext _context;

        public EventRepo(ssdticketsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> Get()
        {
            return await _context.Event.ToListAsync();
        }

        public async Task<Event> Get(int id)
        {
            return await _context.Event.FirstOrDefaultAsync(t => t.EventId == id);
        }

    }
}
