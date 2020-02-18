using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketAPI.Models;

namespace TicketAPI.Interfaces
{
    interface IEventSeatsRepo
    {
        Task<EventSeat> Get(int id);
        Task<IEnumerable<EventSeat>> GetAll(int id);

    }
}
