namespace MyGalaxy_Auction.MailHelper
{
    public interface IMailService
    {
        void SendEmail(string subject, string body, string email);
    }
}
