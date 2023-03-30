using MailKit.Net.Smtp;
using MimeKit;
using ShopGeneral.Data;

namespace ShopGeneral.Mailing
{
    public class MailingService
    {
        public void Mail(Manufacturer manufacturer)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Broderick Beatty", "broderick.beatty16@ethereal.email"));
            message.To.Add(new MailboxAddress(manufacturer.Name, manufacturer.EmailReport));
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.ethereal.email", 587, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("broderick.beatty16@ethereal.email", "KJ5MahY8KMpT6xNE4f");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}