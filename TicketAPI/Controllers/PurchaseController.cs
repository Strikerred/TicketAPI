using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketAPI.Models;
using TicketAPI.Repositories;
using TicketAPI.RequestModels;
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

        // GET /purchase/{purchase_id}
        // returns the purchase with purchase_id
        [HttpGet("{id}")]
        public ActionResult<PurchaseResponse> Get(int id)
        {
            if(!_purchaseRepo.TryGet(id, out PurchaseResponse response))
            {
                return NotFound();
            }

            return Ok(response);
        }

        // POST /purchase
        // register a purchase
        [HttpPost]
        public async  Task<ActionResult<PurchaseResponse>> Post([FromBody] PurchaseRequest purchase)
        {
            var result = await _purchaseRepo.TryAddPurchase(purchase.Seats, purchase.PaymentMethod);
            if (!result.Item1)
            {
                // error encountered when attempting to make purchase
                return BadRequest(result.Item2);
            }

            TicketPurchase tp = (TicketPurchase) result.Item2;
            var response = new PurchaseResponse
            {
                PaymentAmount = tp.PaymentAmount,
                ConfirmationCode = tp.ConfirmationCode,
                PaymentMethod = tp.PaymentMethod,
                PurchaseId = tp.PurchaseId
            };

            return CreatedAtAction(nameof(Get), new { id = tp.PurchaseId }, response);
        }
    }
}