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
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventRepo _repo;

        public EventController(ssdticketsContext context)
        {
            _repo = new EventRepo(context);
        }

        /// <summary>
        /// Get event list.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /event
        /// </remarks> 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return Ok(await _repo.Get());
        }

        /// <summary>
        /// Get an event by eventId
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /event/{id}
        /// </remarks> 
        /// <param name="id"></param>

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
    }
}