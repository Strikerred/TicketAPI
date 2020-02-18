using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class VenueRepo
    {
        private ssdticketsContext _context;

        public VenueRepo(ssdticketsContext context)
        {
            _context = context;
        }

        public IEnumerable<Venue> Get()
        {
            return _context.Venue.ToList();
        }

        public Venue Get(String name)
        {
            return _context.Venue.FirstOrDefault(t => t.VenueName == name);
        }

    }
}
