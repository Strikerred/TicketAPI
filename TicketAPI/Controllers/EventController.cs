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
    public class EventController : ControllerBase
    {
        private readonly EventRepo _repo;

        public EventController(ssdticketsContext context)
        {
            _repo = new EventRepo(context);
        }
        // GET api/event
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return Ok(await _repo.Get());
        }

        // GET api/event/5
        [HttpGet("{id}")]
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