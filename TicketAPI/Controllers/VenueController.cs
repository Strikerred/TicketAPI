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
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly VenueRepo _repo;

        public VenueController(ssdticketsContext context)
        {
            _repo = new VenueRepo(context);
        }

        // GET api/venue
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venue>>> Get()
        {
            return Ok(await _repo.Get());
        }

        // GET api/venue/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByName(String name)
        {
            var item = _repo.Get(name);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(await item);
        }
    }
}