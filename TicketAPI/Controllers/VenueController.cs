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
    [Route("api/venue")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly VenueRepo repo;

        public VenueController(ssdticketsContext context)
        {
            repo = new VenueRepo(context);
        }

        // GET api/venue
        [HttpGet]
        public IEnumerable<Venue> GetVenues()
        {
            return repo.Get();
        }

        // GET api/venue/5
        [HttpGet("{id}")]
        public ActionResult<string> GetVenueByName(String name)
        {
            var item = repo.Get(name);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
        }
    }
}