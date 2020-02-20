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
    [Produces("application/json")]
    public class PurchaseController : ControllerBase
    {
        private PurchaseRepo _purchaseRepo;

        public PurchaseController(PurchaseRepo purchaseRepo)
        {
            _purchaseRepo = purchaseRepo;
        }

        // GET /purchase
        // returns all purchases made so far

        /// <summary>
        /// Returns an array of all purchases made so far
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PurchaseResponse>> GetAll()
        {
            if(!_purchaseRepo.TryGetAll(out List<PurchaseResponse> response))
            {
                return NotFound();
            }

            return Ok(response);
        }

        // GET /purchase/{purchase_id}
        // returns the purchase with id

        /// <summary>
        /// Returns the purchase with id
        /// </summary>
        /// <param name="id">The id of the desired purchase record</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Make a ticket purchase by specifying the desired event_seat_ids in the request body.
        /// </summary>
        /// <param name="purchase"></param>
        /// <returns>The created purchase record is returned if successful. Otherwise, an error message is produced if an event_seat_id does not exist or is already bought.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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