using MailKit.Net.Smtp;
using MimeKit;

namespace MyGalaxy_Auction.MailHelper
{
    public class MailService : IMailService
    {
        public void SendEmail(string subject, string body, string email)
        {
			try
			{
				var emailToSend = new MimeMessage();
                // email ที่เป็นคนส่ง
                emailToSend.From.Add(MailboxAddress.Parse("XxSorasakxX@gmail.com"));
                // email ที่จะส่ง
                emailToSend.To.Add(MailboxAddress.Parse(email));

                emailToSend.Subject = subject;
                emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = body };

                // send mail
                using var emailClient = new SmtpClient();
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("XxSorasakxX@gmail.com", "hzyfughaeextxxwk");
                emailClient.Send(emailToSend);
                emailClient.Disconnect(true);
            }
            catch (Exception ex)
			{
				throw ex;
			}
        }
    }
}
