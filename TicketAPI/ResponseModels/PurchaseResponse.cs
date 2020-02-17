using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.ResponseModels
{
    public class PurchaseResponse
    {
        public int PurchaseId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PaymentAmount { get; set; }
        public string ConfirmationCode { get; set; }
    }
}
