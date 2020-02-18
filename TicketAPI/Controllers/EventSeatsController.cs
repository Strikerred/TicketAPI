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
    [ApiController]
    public class EventSeatsController : ControllerBase
    {
        private readonly EventSeatsRepo repo;

        public EventSeatsController(ssdticketsContext context)
        {
            repo = new EventSeatsRepo(context);
        }

        // GET api/event-seat/5
        [Route("/api/event-seat/{id}")]
        [HttpGet]
        public IActionResult GetEventSeatById(int id)
        {
            var item = repo.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }

        // GET api/event-seat/event/5
        [Route("/api/event-seat/event/{id}")]
        [HttpGet]
        public IEnumerable<EventSeat> GetEventSeatsByEventId(int id)
        {
            return repo.GetAll(id);
        }

    }
}