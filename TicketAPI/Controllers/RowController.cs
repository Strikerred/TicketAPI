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
    [Route("api/section/[controller]")]
    [ApiController]
    public class RowController : Controller
    {
        private readonly TicketsDBContext _context;

        public RowController(TicketsDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRowsBySectionId(long id)
        {
            var rows = new RowRepo(_context).GetRows(id);

            if (rows == null)
            {
                return NotFound();
            }
            return new ObjectResult(rows);
        }
    }
}