using System;
using System.Collections.Generic;

namespace TicketAPI.Models
{
    public partial class Venue
    {
        public Venue()
        {
            Event = new HashSet<Event>();
            Section = new HashSet<Section>();
        }

        public string VenueName { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Section> Section { get; set; }
    }
}
