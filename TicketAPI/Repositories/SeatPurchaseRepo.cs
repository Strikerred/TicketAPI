using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;
using TicketAPI.ResponseModels;

namespace TicketAPI.Repositories
{
    public class SeatPurchaseRepo
    {
        private readonly ssdticketsContext _context;

        public SeatPurchaseRepo(ssdticketsContext context)
        {
            _context = context;
        }
        public IEnumerable<SeatPurchaseResponse> GetSeatPurchases()
        {
            IEnumerable<SeatPurchaseResponse> seatsPurchase =
               _context.TicketPurchaseSeat.Select(sp => new SeatPurchaseResponse()
               {
                    PurchaseId = sp.PurchaseId,
                    EventSeatId = sp.EventSeatId,
                    SeatSubtotal= sp.SeatSubtotal
                });

            return seatsPurchase;
        }
        public IEnumerable<SeatPurchaseResponse> GetSeatsPurchase(long id)
        {
            IEnumerable <SeatPurchaseResponse> seatPurchase = 
                _context.TicketPurchaseSeat.Select(sp => new SeatPurchaseResponse()
                {
                    PurchaseId = sp.PurchaseId,
                    EventSeatId = sp.EventSeatId,
                    SeatSubtotal = sp.SeatSubtotal
                }).Where(sp => sp.PurchaseId == id);

            return seatPurchase;
        }
    }
}
