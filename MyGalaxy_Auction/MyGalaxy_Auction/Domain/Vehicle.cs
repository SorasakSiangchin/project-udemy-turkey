using data_access.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace data_access.Domain
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string BrandAndModel { get; set; } // แบรนด์และรุ่น
        public int ManufacturingYear { get; set; } // ปีการผลิต
        public string Color { get; set; }
        public decimal EngineCapacity { get; set; } // ความจุของเครื่องยนต์
        public decimal Price { get; set; }
        public int Millage { get; set; } // มิลเลจ
        public string PlateNumber { get; set; } // หมายเลขทะเบียน
        public double AuctionPrice { get; set; } // ราคาประมูล
        public string AdditionalInformation { get; set; } // ข้อมูลเพิ่มเติม
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public string Image { get; set; }
        public string SellerId { get; set; }

        [JsonIgnore]
        public ApplicationUser Seller { get; set; }
        public virtual List<Bid> Bids { get; set; }

    }
}
