﻿namespace MyGalaxy_Auction.Dtos
{
    public class UpdateVehicleDTO
    {
        public string BrandAndModel { get; set; }
        public int ManufacturingYear { get; set; }
        public string Color { get; set; }
        public decimal EngineCapacity { get; set; }
        public decimal Price { get; set; }

        public int Millage { get; set; }
        public string PlateNumber { get; set; }

        public double AuctionPrice { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string SellerId { get; set; }
    }
}