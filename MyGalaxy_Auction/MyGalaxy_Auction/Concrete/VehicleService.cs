using AutoMapper;
using core.Models;
using data_access.Context;
using data_access.Domain;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction.Abstraction;
using MyGalaxy_Auction.Dtos;
using System.Net;

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

        public async Task<ApiResponse> ChangeVehicleStatus(int vehicleId)
        {
            var result = await _context
                .Vehicles
                .FindAsync(vehicleId);

            if(result == null)
            {
                _response.IsSuccess = false;
                return _response;
            }

            result.IsActive = false;
            _response.IsSuccess = true;
            await _context.SaveChangesAsync();
            return _response;
        }

        public async Task<ApiResponse> CreateVehicle(CreateVehicleDTO model)
        {
            if (model != null)
            {
                var objDto =  _mapper.Map<Vehicle>(model);
                if (objDto != null)
                {
                    _context.Vehicles.Add(objDto);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        _response.IsSuccess = true;
                        _response.Result = model;
                        _response.StatusCode = HttpStatusCode.OK;
                        return _response;
                    }
                }
            }

            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Ooop! Something went wrong");
            return _response;
        }

        public async Task<ApiResponse> DeleteVehicle(int vehicleId)
        {
            var result = await _context.Vehicles.FindAsync(vehicleId);
            if (result != null)
            {
                _context.Vehicles.Remove(result);
                if (await _context.SaveChangesAsync() > 0)
                {
                    _response.IsSuccess = true;
                    return _response;
                }
            }
            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> GetVehicleById(int vehicleId)
        {
            var result = await _context
                .Vehicles
                .Include(x => x.Seller)
                .FirstOrDefaultAsync(x => x.VehicleId == vehicleId);

            if(result != null)
            {
                _response.Result = result;
                _response.IsSuccess = true;
                return _response;
            }

            _response.IsSuccess = false ;
            return _response;
        }

        public async Task<ApiResponse> GetVehicles()
        {
           var vehicles =
                await _context
                .Vehicles
                .Include(x => x.Seller)
                .ToListAsync();

            if(vehicles != null)
            {
                _response.IsSuccess = true;
                _response.Result = vehicles;
                return _response;
            }

            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> UpdateVehicleResponse(int vehicleId, UpdateVehicleDTO model)
        {
            var result = await _context
                .Vehicles
                .FindAsync(vehicleId);

            if(result != null)
            {
                Vehicle objDto = _mapper.Map(model , result);
                if (await _context.SaveChangesAsync() > 0)
                {
                    _response.IsSuccess= true;
                    _response.Result = objDto;
                    return _response;
                }
            }

            _response.IsSuccess = false;
            return _response;
        }
    }
}
