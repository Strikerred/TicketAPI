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
    [Produces("application/json")]
    public class EventSeatsController : ControllerBase
    {
        private EventSeatRepo _eventSeatRepo;

        public EventSeatsController(EventSeatRepo eventSeatRepo)
        {
            _eventSeatRepo = eventSeatRepo;
        }

        // GET /event-seat/{id}

        /// <summary>
        /// Return an event seat with {id}
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EventSeatResponse> Get(int id)
        {
            if(!_eventSeatRepo.TryGet(id, out EventSeatResponse response))
            {
                return NotFound();
            }

            return Ok(response);
        }

        // GET /event-seat/event/{event_id}
        // Returns an array of all the event seats for an event with { event_id }

        /// <summary>
        /// Returns an array of all the event seats for an event with {event_id}
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpGet("event/{eventId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<EventSeatResponse>> GetByEvent(int eventId)
        {
            if(!_eventSeatRepo.TryGetByEvent(eventId, out List<EventSeatResponse> response))
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}