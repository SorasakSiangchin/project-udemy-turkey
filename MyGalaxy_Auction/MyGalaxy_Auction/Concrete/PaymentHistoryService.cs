using AutoMapper;
using Azure;
using core.Models;
using data_access.Context;
using data_access.Domain;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction.Abstraction;
using MyGalaxy_Auction.Dtos;

namespace MyGalaxy_Auction.Concrete
{
    public class PaymentHistoryService : IPaymentHistoryService
    {
        private readonly ApiResponse _response;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public PaymentHistoryService(ApiResponse response , IMapper mapper , ApplicationDbContext context)
        {
            _response = response;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ApiResponse> CheckIsStatusForAuction(string userId, int vehicleId)
        {
            var response = await _context.PaymentHistories.Where(x => x.UserId == userId && x.VehicleId == vehicleId && x.IsActive == true).FirstOrDefaultAsync();
            if (response != null)
            {
                _response.IsSuccess = true;
                _response.Result = response;
                return _response;
            }
            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> CreatePaymentHistory(CreatePaymentHitoryDto model)
        {
            try
            {
                if (model == null)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Model is not include some fields");
                    return _response;
                }
                else
                {
                    // เพิ่ม Payment History
                    var objDTO = _mapper.Map<PaymentHistory>(model);
                    objDTO.PayDate = DateTime.Now;
                    objDTO.IsActive = true;
                    _context.PaymentHistories.Add(objDTO);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        _response.IsSuccess = true;
                        _response.Result = model;
                        return _response;

                    }
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Ooops! something went wrong!");
                    return _response;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
