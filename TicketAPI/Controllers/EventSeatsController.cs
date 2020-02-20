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

        /// <summary>
        /// Get an eventseat by eventseat Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /event-seat/{id}
        /// </remarks> 
        /// <param name="eventSeatId"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = _repo.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(await item);
        }

        /// <summary>
        /// Get eventseat list by event Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /event-seat/event/{id}
        /// </remarks> 
        /// <param name="eventId"></param>
        [Route("/api/event-seat/event/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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