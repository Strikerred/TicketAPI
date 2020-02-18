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
        public ActionResult<IEnumerable<string>> GetVenues()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/venue/5
        [HttpGet("{id}")]
        public ActionResult<string> GetVenueById(int id)
        {
            return "value";
        }
    }
}