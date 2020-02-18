using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Interfaces
{
    interface IVenueRepo
    {
        Task<Venue> Get(String name);
        Task<IEnumerable<Venue>> Get();
    }
}
