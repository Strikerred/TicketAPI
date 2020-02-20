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
    [Route("api/seat-purchase")]
    [ApiController]
    public class SeatPurchaseController : Controller
    {
        private readonly TicketsDBContext _context;

        public SeatPurchaseController(TicketsDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all seats were purchased
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /seat-purchase
        ///     {
        ///         "purchaseId": 7,
        ///         "eventSeatId": 3001,
        ///         "seatSubtotal": 68.0000
        ///     }
        /// </remarks>
        /// <returns>All seats that have been purchased</returns>
        /// <response code="200">Returns all seats were purchased</response>
        /// <response code="404">Purchases were not found</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var seatPurchase = new SeatPurchaseRepo(_context).GetSeatPurchases();

            if (seatPurchase == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(seatPurchase));
        }

        /// <summary>
        /// Gets all seats by purchase
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /seat-purchase/7
        ///     {
        ///         "purchaseId": 7,
        ///         "eventSeatId": 3001,
        ///         "seatSubtotal": 68.0000
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>All seats by purchase</returns>
        /// <response code="200">Returns all seats by purchase</response>
        /// <response code="404">Purchase were not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(long id)
        {
            var seat = new SeatPurchaseRepo(_context).GetSeatsPurchase(id);

            if (seat == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(seat));
        }
    }
}