using AutoMapper;
using business.Dtos;
using core.Models;
using data_access.Context;
using data_access.Enums;
using data_access.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyGalaxy_Auction.Abstraction;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MyGalaxy_Auction.Concrete
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ApiResponse _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private string secretKey;

        public UserService(
            ApplicationDbContext context,
            IMapper mapper,
            ApiResponse response,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration ,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _response = response;
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            secretKey = configuration.GetValue<string>("SecretKey:jwtKey");
        }

        public async Task<ApiResponse> Login(LoginRequestDto model)
        {
            try
            {
                ApplicationUser userFromDb = _context.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                if (userFromDb != null)
                {
                    bool isValid = await _userManager.CheckPasswordAsync(userFromDb, model.Password);
                    if (!isValid)
                    {
                        _response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        _response.ErrorMessages.Add("Your entry information is not correct");
                        _response.IsSuccess = false;
                        return _response;
                    }
                    var role = await _userManager.GetRolesAsync(userFromDb);
                    JwtSecurityTokenHandler tokenHandler = new();

                    var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

                    SecurityTokenDescriptor tokenDescriptor = new()
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim(ClaimTypes.NameIdentifier, userFromDb.Id),
                        new Claim(ClaimTypes.Email, userFromDb.Email),
                        new Claim(ClaimTypes.Role, role.FirstOrDefault() == null ? "NormalUser" : role.FirstOrDefault()),
                        new Claim("fullName", userFromDb.FullName)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature)

                    };

                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

                    LoginResponseModel _model = new()
                    {
                        Email = userFromDb.Email,
                        Token = tokenHandler.WriteToken(token),
                    };

                    _response.Result = _model;
                    _response.IsSuccess = true;
                    _response.StatusCode = System.Net.HttpStatusCode.OK;
                    return _response;

                }
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Ooops! something went wrong");
                return _response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApiResponse> Register(RegisterRequestDto model)
        {
            try
            {
                var userFromDb = await _context.ApplicationUsers
                    .FirstOrDefaultAsync(x => x.UserName.ToLower() == model.UserName.ToLower());

                if (userFromDb != null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("username already exist");
                    return _response;
                }

                //var newUser = _mapper.Map<ApplicationUser>(model);

                var newUser = new ApplicationUser
                {
                    FullName = model.FullName,
                    UserName = model.UserName,
                    NormalizedEmail = model.UserName.ToUpper(),
                    Email = model.UserName 
                };

                var hashedPassword = _passwordHasher.HashPassword(newUser, model.Password);
                newUser.SecurityStamp = Guid.NewGuid().ToString();
                newUser.PasswordHash = hashedPassword;

                var result = await _userManager.CreateAsync(newUser);

                if (result.Succeeded)
                {
                    var isTrue = _roleManager
                        .RoleExistsAsync(UserType.Administrator.ToString())
                        .GetAwaiter()
                        .GetResult();

                    // RoleExistsAsync => สอบว่าบทบาท (role) ที่ระบุมีอยู่ในระบบหรือไม่
                    if (!_roleManager.RoleExistsAsync(UserType.Administrator.ToString()).GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole(UserType.Administrator.ToString()));
                        await _roleManager.CreateAsync(new IdentityRole(UserType.Seller.ToString()));
                        await _roleManager.CreateAsync(new IdentityRole(UserType.NormalUser.ToString()));
                    }

                    if (model.UserType.ToString().ToLower() == UserType.Administrator.ToString().ToLower())
                    {
                        await _userManager.AddToRoleAsync(newUser, UserType.Administrator.ToString());
                    }

                    if (model.UserType.ToString().ToLower() == UserType.NormalUser.ToString().ToLower())
                    {
                        await _userManager.AddToRoleAsync(newUser, UserType.NormalUser.ToString());

                    }

                    else if (model.UserType.ToString().ToLower() == UserType.Seller.ToString().ToLower())
                    {
                        await _userManager.AddToRoleAsync(newUser, UserType.Seller.ToString());

                    }

                    _response.StatusCode = HttpStatusCode.Created;
                    _response.IsSuccess = true;
                    return _response;
                }

                foreach (var error in result.Errors)
                    _response.ErrorMessages.Add(error.ToString());


                return _response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
