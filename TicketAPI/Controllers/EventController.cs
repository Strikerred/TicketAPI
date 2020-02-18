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
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventRepo repo;

        public EventController(ssdticketsContext context)
        {
            repo = new EventRepo(context);
        }
        // GET api/event
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            return Ok(repo.Get());
        }

        // GET api/event/5
        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var item = repo.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}