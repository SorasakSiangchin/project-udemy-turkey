using Azure;
using core.Models;
using data_access.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyGalaxy_Auction.Common;
using MyGalaxy_Auction.Dtos;
using Stripe;

namespace MyGalaxy_Auction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        private readonly ApiResponse _response;
        private readonly StripeSettings _stripeSettings;

        public PaymentController(
            IConfiguration configuration , 
            ApplicationDbContext context , 
            ApiResponse response ,
            IOptions<StripeSettings> options)
        {
            _configuration = configuration;
            _context = context;
            _response = response;
            _stripeSettings = options.Value;
        }

        // api ชำระเงินโดยดูยอดเงินจาก database
        [HttpPost("Pay")]
        public async Task<ActionResult<ApiResponse>> MakePayment(string userId, int vehicleId)
        {
            //StripeConfiguration.ApiKey = _configuration.GetValue<string>("StripeSettings:SecretKey");
             StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
             var amountToBePaid = await _context.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == vehicleId);

            var options = new PaymentIntentCreateOptions
            {
                Amount = (int)(amountToBePaid.AuctionPrice * 100),
                Currency = "THB",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var response = service.Create(options);

            CreatePaymentHitoryDto model = new CreatePaymentHitoryDto
            {
                ClientSecret = response.ClientSecret,
                StripePaymentIntentId = response.Id,
                UserId = userId,
                VehicleId = vehicleId,
            };

            _response.Result = model;
            _response.IsSuccess = true;
            _response.StatusCode = System.Net.HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
