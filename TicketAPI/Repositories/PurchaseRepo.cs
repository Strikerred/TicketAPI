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

        public PurchaseRepo(ssdticketsContext context)
        {
            _context = context;
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
    }
}
