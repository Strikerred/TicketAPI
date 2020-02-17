﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult GetAll()
        {
            var sections = new SectionRepo(_context).GetAll();

            if (sections == null || sections.Count <= 0)
            {
                return NotFound();
            }
            return new ObjectResult(sections);
        }        
    }
}