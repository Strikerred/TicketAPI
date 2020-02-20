using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;
using TicketAPI.ResponseModels;

namespace TicketAPI.Repositories
{
    public class PurchaseRepo
    {
        private ssdticketsContext _context;
        private Random _rand;

        public PurchaseRepo(ssdticketsContext context)
        {
            _context = context;
            _rand = new Random();
        }

        public bool TryGetAll(out List<PurchaseResponse> response)
        {
            var target = _context.TicketPurchase.ToList();

            if (target.Any())
            {
                response = new List<PurchaseResponse>();

                foreach (TicketPurchase tp in target)
                {
                    response.Add(new PurchaseResponse
                    {
                        PaymentAmount = tp.PaymentAmount,
                        ConfirmationCode = tp.ConfirmationCode,
                        PaymentMethod = tp.PaymentMethod,
                        PurchaseId = tp.PurchaseId
                    });
                }
                return true;
            }

            // no purchases found
            response = null;
            return false;
        }

        public bool TryGet(int id, out PurchaseResponse response)
        {
            var target = _context.TicketPurchase.SingleOrDefault(tp => tp.PurchaseId == id);

            if (target != null)
            {
                response = new PurchaseResponse
                {
                    PaymentAmount = target.PaymentAmount,
                    ConfirmationCode = target.ConfirmationCode,
                    PaymentMethod = target.PaymentMethod,
                    PurchaseId = target.PurchaseId
                };
                return true;
            }

            // purchases not found
            response = null;
            return false;
        }

        // returns a tuple where Item1 corresponds to the success of the attempt, and Item2 is the associated status message
        public async Task<Tuple<bool, object>> TryAddPurchase(IEnumerable<int> eventSeatIds, string paymentMethod)
        {
            // check that event seats with the given ids exist and are available for purchase
            var purchaseSeats = new List<EventSeat>();
            foreach (int id in eventSeatIds)
            {
                var target = _context.EventSeat.SingleOrDefault(es => es.EventSeatId == id);
                if (target == null)
                {
                    return new Tuple<bool, object>(false, $"An event seat with event_seat_id {id} does not exist");
                }

                bool isPurchased = _context.TicketPurchaseSeat.ToList().Any(tps => tps.EventSeatId == id);
                if (isPurchased)
                {
                    return new Tuple<bool, object>(false, $"The event seat with event_seat_id {id} has already been purchased");
                }
                
                purchaseSeats.Add(target);
            }

            // make the purchase
            var purchase = new TicketPurchase { 
                PaymentMethod = paymentMethod,
                ConfirmationCode = _rand.Next(100000, 999999).ToString() 
            };
            var ticketPurchases = new List<TicketPurchaseSeat>();
            decimal totalPurchaseCost = 0;
            
            foreach (EventSeat es in purchaseSeats)
            {
                decimal seatPrice = (decimal) _context.Seat.SingleOrDefault(s => s.SeatId == es.SeatId).Price;
                var seatPurchase = new TicketPurchaseSeat
                {
                    EventSeat = es,
                    Purchase = purchase,
                    SeatSubtotal = es.EventSeatPrice + seatPrice
                };
                ticketPurchases.Add(seatPurchase);
                totalPurchaseCost += (decimal) seatPurchase.SeatSubtotal;
            }

            purchase.PaymentAmount = totalPurchaseCost;
            _context.TicketPurchase.Add(purchase);
            await _context.SaveChangesAsync();

            foreach (TicketPurchaseSeat ticket in ticketPurchases)
            {
                _context.TicketPurchaseSeat.Add(ticket);
            }
            await _context.SaveChangesAsync();

            return new Tuple<bool, object>(true, purchase);
        }
    }
}
