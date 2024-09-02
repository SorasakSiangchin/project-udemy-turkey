using business.Dtos;
using core.Models;

namespace MyGalaxy_Auction.Abstraction
{
    public interface IUserService
    {
        Task<ApiResponse> Register(RegisterRequestDto model);
        Task<ApiResponse> Login(LoginRequestDto model);
    }
}
