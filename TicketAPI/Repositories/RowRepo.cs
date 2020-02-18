using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;
using TicketAPI.ResponseModels;

namespace TicketAPI.Repositories
{
    public class RowRepo
    {
        private readonly TicketsDBContext _context;

        public RowRepo(TicketsDBContext context)
        {
            _context = context;
        }
        public IEnumerable<RowResponse> GetRows()
        {
            IEnumerable<RowResponse> rows =
               _context.Row.Select(r => new RowResponse()
               {
                   RowId = r.RowId,
                   RowName = r.RowName,
                   SectionId = r.SectionId
               });

            return rows;
        }

        public RowResponse GetRow(long id)
        {
            Row targetRow = _context.Row.Where(s => s.RowId == id).FirstOrDefault();

            RowResponse row = new RowResponse()
            {
                RowId = targetRow.RowId,
                RowName = targetRow.RowName,
                SectionId = targetRow.SectionId
            };

            return row;
        }

        public IEnumerable<RowResponse> GetRowBySectionId(long id)
        {
            IEnumerable<RowResponse> rows =
             _context.Row.Select(r => new RowResponse()
             {
                 RowId = r.RowId,
                 RowName = r.RowName,
                 SectionId = r.SectionId
             }).Where(r => r.SectionId == id);

            return rows;
        }
    }
}
