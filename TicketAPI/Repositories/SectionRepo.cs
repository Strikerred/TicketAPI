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

        public Section GetSection(long id)
        {
            return _context.Section.FirstOrDefault(s => s.SectionId == id);
        }
    }
}
