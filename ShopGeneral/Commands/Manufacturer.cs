using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MimeKit.Cryptography;
using ShopGeneral.CategoryValidator;
using ShopGeneral.Data;
using ShopGeneral.Mailing;

namespace TestConsole.Commands
{
        public class Manufacturer : ConsoleAppBase
        {
            MailingService mailingService = new MailingService();

            //manufacturer sendreport
            [Command("sendreport", "sends report to manufacturer")]
            public async void sendReportToManufacturer()
            {
            //Ha in dbcontext, köra klassen MailingService.

            var dbContext = this.Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Console.WriteLine("MAILREPORT FUNKAR");

            mailingService.MailAllManufacturers(dbContext.Manufacturers);
            

            }
        }
}
