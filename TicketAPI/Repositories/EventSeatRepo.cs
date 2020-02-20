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

        public bool TryGetByEvent(int eventId, out List<EventSeatResponse> response)
        {
            var target = _context.EventSeat.Where(es => es.EventId == eventId);

            if (target.Any())
            {
                response = new List<EventSeatResponse>();

                foreach (EventSeat es in target)
                {
                    bool isPurchased = _context.TicketPurchaseSeat.ToList().Any(tps => tps.EventSeatId == es.EventSeatId);
                    response.Add(new EventSeatResponse
                    {
                        EventSeatId = es.EventSeatId,
                        SeatId = es.SeatId,
                        EventId = es.EventId,
                        EventSeatPrice = es.EventSeatPrice,
                        IsAvailable = !isPurchased
                    });
                }
                return true;
            }

            // event seats not found
            response = null;
            return false;
        }
    }
}
