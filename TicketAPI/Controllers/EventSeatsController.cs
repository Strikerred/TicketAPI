using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    [Route("api/event-seat")]
    [ApiController]
    public class EventSeatsController : ControllerBase
    {
        private readonly ssdticketsContext _context;

        public EventSeatsController(ssdticketsContext context)
        {
            _context = context;
        }
    }
}