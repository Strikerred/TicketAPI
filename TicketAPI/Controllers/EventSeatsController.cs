using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Repositories;
using TicketAPI.ResponseModels;

namespace TicketAPI.Controllers
{
    [Route("api/event-seat")]
    [ApiController]
    public class EventSeatsController : ControllerBase
    {
        private EventSeatRepo _eventSeatRepo;

        public EventSeatsController(EventSeatRepo eventSeatRepo)
        {
            _eventSeatRepo = eventSeatRepo;
        }

        // GET /event-seat/{id}
        [HttpGet("{id}")]
        public ActionResult<EventSeatResponse> Get(int id)
        {
            if(!_eventSeatRepo.TryGet(id, out EventSeatResponse response))
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}