using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketAPI.ResponseModels
{
    public class SectionResponse
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public string VenueName { get; set; }
    }
}
