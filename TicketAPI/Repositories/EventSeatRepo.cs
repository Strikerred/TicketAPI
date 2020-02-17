using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;
using TicketAPI.ResponseModels;

namespace TicketAPI.Repositories
{
    public class EventSeatRepo
    {
        private ssdticketsContext _context;

        public EventSeatRepo(ssdticketsContext context)
        {
            _context = context;
        }

        public bool TryGet(int eventSeatId, out EventSeatResponse response)
        {
            EventSeat target = _context.EventSeat.SingleOrDefault(es => es.EventSeatId == eventSeatId);

            if (target != null)
            {
                bool isPurchased = _context.TicketPurchaseSeat.ToList().Any(tps => tps.EventSeatId == eventSeatId);
                response = new EventSeatResponse
                {
                    EventSeatId = target.EventSeatId,
                    SeatId = target.SeatId,
                    EventId = target.EventId,
                    EventSeatPrice = target.EventSeatPrice,
                    IsAvailable = !isPurchased
                };
                return true;
            }

            // event seat not found
            response = null;
            return false;
        }
    }
}
