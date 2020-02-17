using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicketAPI.Controllers
{
    public class EventSeatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}