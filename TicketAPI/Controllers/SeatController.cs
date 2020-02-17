using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;
using TicketAPI.Repositories;

namespace TicketAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/rows/section")]
    public class SeatController : Controller
    {
        private readonly TicketsDBContext _context;

        public SeatController(TicketsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSeatByIdRow(long id)
        {
            var seat = new SeatRepo(_context).GetSeat(id);

            if (seat == null)
            {
                return NotFound();
            }
            return new ObjectResult(seat);
        }
    }
}