using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.RequestModels
{
    public class PurchaseRequest
    {
        public IEnumerable<int> Seats { get; set; }
        public string PaymentMethod { get; set; }
    }
}
