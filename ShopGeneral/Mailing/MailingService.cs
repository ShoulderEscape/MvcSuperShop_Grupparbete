using MailKit.Net.Smtp;
using MimeKit;
using ShopGeneral.Data;

namespace ShopGeneral.Mailing
{
    public class MailingService
    {

        public void MailAllManufacturers(IEnumerable<Manufacturer> manufacturers) => manufacturers.ToList().ForEach(m => { Mail(m); });

        private void Mail(Manufacturer manufacturer)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Emmitt Macejkovic", "emmitt.macejkovic43@ethereal.email"));
            message.To.Add(new MailboxAddress(manufacturer.Name, manufacturer.EmailReport.Replace(" ", "")));
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
                client.Authenticate("emmitt.macejkovic43@ethereal.email", "y7caa1nUNyuVsMunF1");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}