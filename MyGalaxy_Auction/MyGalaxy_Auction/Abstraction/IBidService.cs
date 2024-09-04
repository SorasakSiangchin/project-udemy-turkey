using core.Models;
using MyGalaxy_Auction.Dtos;

namespace MyGalaxy_Auction.Abstraction
{
    public interface IBidService
    {
        Task<ApiResponse> CreateBid(CreateBidDTO model);
        Task<ApiResponse> UpdateBid(int bidId, UpdateBidDTO model);
        Task<ApiResponse> GetBidById(int bidId);
        Task<ApiResponse> CancelBid(int bidId);

        Task<ApiResponse> AutomaticallyCreateBid(CreateBidDTO model);
        Task<ApiResponse> GetBidByVehicleId(int vehicleId);
    }
}
