using AutoMapper;
using core.Models;
using data_access.Context;
using data_access.Domain;
using Microsoft.EntityFrameworkCore;
using MyGalaxy_Auction.Abstraction;
using MyGalaxy_Auction.Dtos;
using MyGalaxy_Auction.MailHelper;

namespace MyGalaxy_Auction.Concrete
{
    public class BidService : IBidService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ApiResponse _response;
        private readonly IMailService _mailService;

        public BidService(ApplicationDbContext context 
            , IMapper mapper 
            , ApiResponse response
            , IMailService mailService)
        {
            _context = context;
            _mapper = mapper;
            _response = response;
            _mailService = mailService;
        }

        // สร้างการประมูลอัตโนมัติ โดยเพิ่มเงินในการประมูลเดิม 10%
        public async Task<ApiResponse> AutomaticallyCreateBid(CreateBidDTO model)
        {
            var isPaid = await CheckIsPaidAuction(model.UserId, model.VehicleId);
            if (!isPaid)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please before pay auction price");
                return _response;
            }

            var result = await _context.Bids.Where(x => x.VehicleId == model.VehicleId && x.Vehicle.IsActive == true).OrderByDescending(x => x.BidAmount).ToListAsync();
            if (result.Count == 0)
            {
                _response.IsSuccess = false;
                return _response;
            }

            var objDTO = _mapper.Map<Bid>(model);
            objDTO.BidAmount = result[0].BidAmount + (result[0].BidAmount * 10) / 100;
            objDTO.BidDate = DateTime.Now;
            _context.Bids.Add(objDTO);
            await _context.SaveChangesAsync();
            _response.IsSuccess = true;
            _response.Result = result;
            return _response;
        }

        public Task<ApiResponse> CancelBid(int bidId)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> CreateBid(CreateBidDTO model)
        {
            var returnValue = await CheckIsActive(model.VehicleId);
            var isPaid = await CheckIsPaidAuction(model.UserId , model.VehicleId);

            // ชำระเงินก่อนทำการประมูล
            //if (!isPaid)
            //{
            //    _response.IsSuccess = false;
            //    _response.ErrorMessages.Add("Please before pay auction price");
            //    return _response;
            //}

            // รถคันนี้ไม่ได้ใช้งาน
            if (returnValue == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("this car is not active");
            }

            // เงินค่ารถ มากกว่า เงินที่จะจ่าย
            if (returnValue.Price >= model.BidAmount)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add($"You should surpass the default price for this car {returnValue.Price}");
                return _response;
            }
            
            if (model != null)
            {
                // ดึงข้อมูลเสนอราคาที่มากที่สุด
                var topPrice = 
                    await _context
                    .Bids
                    .Where(x => x.VehicleId == model.VehicleId)
                    .OrderByDescending(x => x.BidAmount)
                    .ToListAsync();

                if (topPrice.Count != 0)
                {
                    // ว่าเราประมูลด้วยจำนวนเงินที่มากกว่าเงินที่ประมูล ณ ปัจจุบันหรือป่าว
                    if (topPrice[0].BidAmount >= model.BidAmount)
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages.Add("Entry bid amount,not lower than higher price to the system; higher price is : " + topPrice[0].BidAmount);
                        return _response;
                    }
                }

                Bid bid = _mapper.Map<Bid>(model);
                bid.BidDate = DateTime.Now;
                await _context.Bids.AddAsync(bid);

                if (await _context.SaveChangesAsync() > 0)
                {
                    var userDetail = await _context
                        .Bids
                        .Include(x => x.User)
                        .Where(x => x.UserId == model.UserId)
                        .FirstOrDefaultAsync();

                    _mailService.SendEmail("Your bid is success", "Your bid is :" + bid.BidAmount, bid.User.UserName);

                    _response.IsSuccess = true;
                    _response.Result = true;
                    return _response;
                }
            }

            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Ooops! sometihng went wrong");
            return _response;
        }

        public async Task<ApiResponse> GetBidById(int bidId)
        {
            var result = await _context.Bids.Include(x => x.User).Where(x => x.BidId == bidId).FirstOrDefaultAsync();
            if (result == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("bid is not found");
                return _response;
            }

            _response.IsSuccess = true;
            _response.Result = result;
            return _response;
        }

        public async Task<ApiResponse> GetBidByVehicleId(int vehicleId)
        {
            var obj = await _context.Bids.Include(x => x.Vehicle).ThenInclude(x => x.Bids).Where(x => x.VehicleId == vehicleId).ToListAsync();
            if (obj != null)
            {
                _response.IsSuccess = true;
                _response.Result = obj;
                return _response;
            }
            _response.IsSuccess = false;
            return _response;
        }

        public async Task<ApiResponse> UpdateBid(int bidId, UpdateBidDTO model)
        {
            var isPaid = await CheckIsPaidAuction(model.UserId, model.VehicleId);
            if (!isPaid)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Please before pay auction price");
                return _response;
            }

            var result = await _context.Bids.FindAsync(bidId);
            if (result == null)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("bid is not found");
                return _response;
            }

            // เช็คว่าเงินที่ประมูณมามากกว่าว่าเงินก่อนเดิม 
            // และใบเสนอราคาใช่ของเราหรือป่าว
            if (result.BidAmount < model.BidAmount && result.UserId == model.UserId)
            {
                var objDTO = _mapper.Map(model, result);
                objDTO.BidDate = DateTime.Now;
                _response.IsSuccess = true;
                _response.Result = objDTO;
                await _context.SaveChangesAsync();
                return _response;
            }
            else if (result.BidAmount >= model.BidAmount)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("You are not entry low price than your old bid amount,your older bid amount is : " + result.BidAmount);
                return _response;
            }

            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Something went wrong");
            return _response;
        }

        // ดึงข้อมูล single vehicle 
        private async Task<Vehicle> CheckIsActive(int vehicleId)
        {

            var obj = await _context
                .Vehicles
                .Where(x => x.VehicleId == vehicleId && x.IsActive == true && x.EndTime >= DateTime.Now)
                .FirstOrDefaultAsync();
            
            if (obj != null)
                return obj;
            
            return null;
        }

        // ดึงข้อมูลการชำระเงินของลูกค้า
        private async Task<bool> CheckIsPaidAuction(string userId, int vehicleId)
        {
            var obj = await _context
                .PaymentHistories
                .Where(x => x.UserId == userId && x.VehicleId == vehicleId && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (obj != null) return true;
            
            return false;
        }
    }
}
