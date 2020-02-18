using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;

namespace TicketAPI.Controllers
{
    [Route("api/venue")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly ssdticketsContext _context;

        public VenueController(ssdticketsContext context)
        {
            _context = context;
        }


        // GET api/venue
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/venue/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
    }
}