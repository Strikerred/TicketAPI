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
    public class SeatController : Controller
    {
        private readonly TicketsDBContext _context;

        public SeatController(TicketsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var seats = new SeatRepo(_context).GetSeats();

            if (seats == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(seats));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(long id)
        {
            var seat = new SeatRepo(_context).GetSeat(id);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(seat));
        }

        [HttpGet("row/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetByRowId(long id)
        {
            var seats = new SeatRepo(_context).GetSeatByRowId(id);

            if (seats == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(seats));
        }
    }
}