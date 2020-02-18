using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Interfaces;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class VenueRepo : IVenueRepo
    {
        private ssdticketsContext _context;

        public VenueRepo(ssdticketsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Venue>> Get()
        {
            return await _context.Venue.ToListAsync();
        }

        public async Task<Venue> Get(String name)
        {
            return await _context.Venue.FirstOrDefaultAsync(t => t.VenueName == name);
        }

    }
}
