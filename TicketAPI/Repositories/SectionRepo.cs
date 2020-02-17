using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class SectionRepo
    {
        private readonly TicketsDBContext _context;

        public SectionRepo(TicketsDBContext context)
        {
            _context = context;
        }

        public List<Section> GetAll()
        {
            return _context.Section.ToList();
        }        

        public List<Seat> GetSeats(long id)
        {
            return _context.Seat.Where(s => s.RowId == id).ToList();
        }
    }
}
