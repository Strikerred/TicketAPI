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
    public class VenueController : ControllerBase
    {
        private readonly VenueRepo _repo;

        public VenueController(ssdticketsContext context)
        {
            _repo = new VenueRepo(context);
        }

        /// <summary>
        /// Get venue list
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /venue
        /// </remarks> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Venue>>> Get()
        {
            return Ok(await _repo.Get());
        }

        /// <summary>
        /// Get an venue by venue_name
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /venue/{venue_name}
        /// </remarks> 
        /// <param name="venue_name"></param>
        [HttpGet("{venue_name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByName(string venue_name)
        {
            var item = _repo.Get(venue_name);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(await item);
        }
    }
}