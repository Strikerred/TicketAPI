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

        /// <summary>
        /// Gets all sections
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /section
        ///     {
        ///         "sectionId": 1,
        ///         "sectionName": "Section 1",
        ///         "venueName": "BCIT Stadium"
        ///     }
        /// </remarks>
        /// <returns>All sections</returns>
        /// <response code="200">Returns all sections</response>
        /// <response code="404">Sections were not found</response>
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

        /// <summary>
        /// Gets an specific section
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /section/1
        ///     {
        ///         "sectionId": 1,
        ///         "sectionName": "Section 1",
        ///         "venueName": "BCIT Stadium"
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Specific section</returns>
        /// <response code="200">Returns a section</response>
        /// <response code="404">Section were not found</response>
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