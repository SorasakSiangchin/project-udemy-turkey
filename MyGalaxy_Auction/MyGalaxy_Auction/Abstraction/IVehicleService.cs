using core.Models;
using MyGalaxy_Auction.Dtos;

namespace MyGalaxy_Auction.Abstraction
{
    public interface IVehicleService
    {
        Task<ApiResponse> CreateVehicle(CreateVehicleDTO model);
        Task<ApiResponse> GetVehicles();
        Task<ApiResponse> UpdateVehicleResponse(int vehicleId , UpdateVehicleDTO model);
        Task<ApiResponse> DeleteVehicle(int vehicleId);
        Task<ApiResponse> GetVehicleById(int vehicleId);
        Task<ApiResponse> ChangeVehicleStatus(int vehicleId);
    }
}
