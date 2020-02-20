using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.ResponseModels
{
    public class RowResponse
    {
        public int RowId { get; set; }
        public string RowName { get; set; }
        public int? SectionId { get; set; }
    }
}
