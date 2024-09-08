using core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGalaxy_Auction.Abstraction;
using MyGalaxy_Auction.Dtos;
using MyGalaxy_Auction.Models;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentHistoryController : ControllerBase
    {
        private readonly IPaymentHistoryService _paymentHistoryService;

        public PaymentHistoryController(
            IPaymentHistoryService paymentHistoryService)
        {
            _paymentHistoryService = paymentHistoryService;
        }

        [HttpPost("AddHistory")]
        public async Task<ActionResult> CreatePaymentHistory(CreatePaymentHitoryDto model)
        {
            if(ModelState.IsValid)
            {
                var response = await _paymentHistoryService.CreatePaymentHistory(model);
                if(!response.IsSuccess)
                {
                    return BadRequest(response);
                }

                return Ok(response);
            }

            return BadRequest();
        }

        [HttpPost("CheckStatus")]
        public async Task<ActionResult<ApiResponse>> CheckStatusAuction(CheckStatusModel model)
        {
            var response = await _paymentHistoryService.CheckIsStatusForAuction(model.UserId, model.VehicleId);
            return Ok(response);
        }

    }
}
