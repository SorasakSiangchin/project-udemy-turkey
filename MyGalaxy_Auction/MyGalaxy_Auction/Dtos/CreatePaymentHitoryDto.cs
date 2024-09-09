namespace MyGalaxy_Auction.Dtos
{
    public class CreatePaymentHitoryDto
    {
        public string ClientSecret { get; set; }
        public string StripePaymentIntentId { get; set; }
        public string UserId { get; set; }
        public int VehicleId { get; set; }
    }
}
