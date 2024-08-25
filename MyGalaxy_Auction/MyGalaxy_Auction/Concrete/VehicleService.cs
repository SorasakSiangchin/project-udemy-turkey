using AutoMapper;
using core.Models;
using data_access.Context;
using MyGalaxy_Auction.Abstraction;
using MyGalaxy_Auction.Dtos;

namespace MyGalaxy_Auction.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public VehicleService(
            ApplicationDbContext context , 
            IMapper mapper ,
            ApiResponse response)
        {
            _context = context;
            _mapper = mapper;
            _response = response;
        }

        public Task<ApiResponse> ChangeVehicleStatus(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> CreateVehicle(CreateVehicleDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteVehicle(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetVehicleById(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> GetVehicles()
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateVehicleResponse(int vehicleId, UpdateVehicleDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
