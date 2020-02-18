using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Interfaces
{
    interface IEventRepo
    {
        Task<Event> Get(int id);
        Task<IEnumerable<Event>> Get();
    }
}
