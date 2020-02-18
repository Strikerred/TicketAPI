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
        public IActionResult GetEventSeatById(int id)
        {
            var item = repo.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // GET api/event-seat/event/5
        [Route("/api/event-seat/event/{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<EventSeat>> GetEventSeatsByEventId(int id)
        {
            var items = repo.GetAll(id);

            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

    }
}