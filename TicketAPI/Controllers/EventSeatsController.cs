using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Interfaces;
using TicketAPI.Models;
using TicketAPI.Repositories;

namespace TicketAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/event-seat")]
    [ApiController]
    public class EventSeatsController : ControllerBase
    {
        public readonly EventSeatsRepo _repo;
        public EventSeatsController(ssdticketsContext context)
        {
            _repo = new EventSeatsRepo(context);
        }

        // GET api/event-seat/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = _repo.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(await item);
        }

        // GET api/event-seat/event/5
        [Route("/api/event-seat/event/{id}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventSeat>>> GetByEventId(int id)
        {
            var items = _repo.GetAll(id);

            if (items == null)
            {
                return NotFound();
            }

            return Ok(await items);
        }

    }
}