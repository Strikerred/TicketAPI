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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : Controller
    {
        private readonly TicketsDBContext _context;

        public SectionController(TicketsDBContext context)
        {
            _context = context;
        }        

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var sections = new SectionRepo(_context).GetAll();

            if (sections == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(sections));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(long id)
        {         
            var section = new SectionRepo(_context).GetSection(id);

            if (section == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(section));
        }
    }
}