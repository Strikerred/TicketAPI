﻿using System;
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

            if (rows == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(rows));
        }

        /// <summary>
        /// Gets all rows
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /row
        ///     {
        ///         "rowId": 1,
        ///         "rowName": "Row 1",
        ///         "sectionId": 1
        ///     }
        /// </remarks>
        /// <returns>All rows</returns>
        /// <response code="200">Returns all rows</response>
        /// <response code="404">Rows were not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(long id)
        {
            var row = new RowRepo(_context).GetRow(id);

            if (row == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(row));
        }

        /// <summary>
        /// Gets all rows by section
        /// </summary> 
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /row/section/1
        ///     {
        ///         "rowId": 1,
        ///         "rowName": "Row 1",
        ///         "sectionId": 1
        ///     }
        /// </remarks>
        /// <returns>All rows by section</returns>
        /// <response code="200">Returns all rows by section</response>
        /// <response code="404">Rows were not found</response>
        [HttpGet("section/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetBySectionId(long id)
        {
            var rows = new RowRepo(_context).GetRowBySectionId(id);

            if (rows == null)
            {
                return NotFound();
            }

            return Ok(new ObjectResult(rows));
        }
    }
}