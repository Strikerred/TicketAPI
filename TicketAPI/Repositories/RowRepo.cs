using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Repositories
{
    public class RowRepo
    {
        private readonly TicketsDBContext _context;

        public RowRepo(TicketsDBContext context)
        {
            _context = context;
        }
        public List<Row> GetRows(long id)
        {
            return _context.Row.Where(s => s.SectionId == id).ToList();
        }
    }
}
