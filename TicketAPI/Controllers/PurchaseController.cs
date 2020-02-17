using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Repositories;
using TicketAPI.ResponseModels;

namespace TicketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private PurchaseRepo _purchaseRepo;

        public PurchaseController(PurchaseRepo purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
        }


        // GET /purchase
        // returns all purchases made so far
        [HttpGet]
        public ActionResult<List<PurchaseResponse>> GetAll()
        {
            if(!_purchaseRepo.TryGetAll(out List<PurchaseResponse> response))
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}