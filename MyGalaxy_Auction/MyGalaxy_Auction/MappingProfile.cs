using AutoMapper;
using data_access.Domain;
using MyGalaxy_Auction.Dtos;

namespace MyGalaxy_Auction
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateVehicleDTO, Vehicle>().ReverseMap();
            CreateMap<UpdateVehicleDTO, Vehicle>();
            CreateMap<CreateBidDTO, Bid>();
            CreateMap<UpdateBidDTO, Bid>();

            CreateMap<CreatePaymentHitoryDto, PaymentHistory>();
        }
    }
}
