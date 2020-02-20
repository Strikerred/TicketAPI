using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;
using TicketAPI.ResponseModels;

namespace TicketAPI.Repositories
{
    public class SeatRepo
    {
        private readonly TicketsDBContext _context;

        public SeatRepo(TicketsDBContext context)
        {
            _context = context;
        }
        public IEnumerable<SeatResponse> GetSeats()
        {
            IEnumerable<SeatResponse> seats =
               _context.Seat.Select(s => new SeatResponse()
               {
                   SeatId = s.SeatId,
                   Price = s.Price,
                   RowId = s.RowId,
                   SectionName = s.Row.Section.SectionName
               });

            return seats;
        }
        public SeatResponse GetSeat(long id)
        {
            SeatResponse seat = _context.Seat.Where(s => s.SeatId == id).Select(s => new SeatResponse()
                {
                    SeatId = s.SeatId,
                    Price = s.Price,
                    RowId = s.RowId,
                    SectionName = s.Row.Section.SectionName
                }).FirstOrDefault();

            return seat;
        }

        public IEnumerable<SeatResponse> GetSeatByRowId(long id)
        {
            IEnumerable<SeatResponse> seats =
              _context.Seat.Select(s => new SeatResponse()
              {
                  SeatId = s.SeatId,
                  Price = s.Price,
                  RowId = s.RowId,
                  SectionName = s.Row.Section.SectionName
              }).Where(s => s.RowId == id);

            return seats;
        }
    }
}
