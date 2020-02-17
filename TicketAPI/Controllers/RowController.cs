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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAll()
        {
            var rows = new RowRepo(_context).GetRows();

            if (rows == null || rows.Count == 0)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(rows));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(long id)
        {
            var row = new RowRepo(_context).GetRow(id);

            if (row == null || row.Count == 0)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(row));
        }
    }
}