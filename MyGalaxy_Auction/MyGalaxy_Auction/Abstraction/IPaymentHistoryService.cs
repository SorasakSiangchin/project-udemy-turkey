using core.Models;
using MyGalaxy_Auction.Dtos;

namespace MyGalaxy_Auction.Abstraction
{
    public interface IPaymentHistoryService
    {
        Task<ApiResponse> CreatePaymentHistory(CreatePaymentHitoryDto model);
        Task<ApiResponse> CheckIsStatusForAuction(string userId , int vehicleId);
    }
}
