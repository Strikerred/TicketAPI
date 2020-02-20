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
        private readonly ssdticketsContext _context;

        public SeatController(ssdticketsContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all seats
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /seat
        ///     {
        ///         "seatId": 1,
        ///         "price": 12.5000,
        ///         "rowId": 1,
        ///         "sectionName": "Section 1"
        ///     }
        /// </remarks>
        /// <returns>All seats</returns>
        /// <response code="200">Returns all seat</response>
        /// <response code="404">Seats were not found</response>
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

        /// <summary>
        /// Gets all seats by row
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /seat/row/1
        ///     {
        ///         "seatId": 1,
        ///         "price": 12.5000,
        ///         "rowId": 1,
        ///         "sectionName": "Section 1"
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>All seats by row</returns>
        /// <response code="200">Returns all seats by row</response>
        /// <response code="404">Seats were not found</response>
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

        /// <summary>
        /// Gets a seat
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /seat/1
        ///     {
        ///         "seatId": 1,
        ///         "price": 12.5000,
        ///         "rowId": 1,
        ///         "sectionName": "Section 1"
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>An specific seat</returns>
        /// <response code="200">Returns an specific seat</response>
        /// <response code="404">Seat were not found</response>
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