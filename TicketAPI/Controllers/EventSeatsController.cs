using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;
using TicketAPI.Repositories;

namespace TicketAPI.Controllers
{
    [Route("api/event-seat")]
    [ApiController]
    public class EventSeatsController : ControllerBase
    {
        private readonly EventSeatsRepo repo;

        public EventSeatsController(ssdticketsContext context)
        {
            repo = new EventSeatsRepo(context);
        }

        // GET api/event-seat/5
        [HttpGet("{id}")]
        public ActionResult<string> GetEventSeatsById(int id)
        {
            return "value";
        }
        // GET api/event-seat/event/5
        [HttpGet("/event/{id}")]
        public ActionResult<string> GetEventSeatsByEventId(int id)
        {
            return "value";
        }

    }
}