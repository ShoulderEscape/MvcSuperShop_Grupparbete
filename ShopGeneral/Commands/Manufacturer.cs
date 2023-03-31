using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ShopGeneral.CategoryValidator;
using ShopGeneral.Data;


namespace TestConsole.Commands
{
        public class Manufacturer : ConsoleAppBase
        {
            //manufacturer sendreport
            [Command("sendreport", "sends report to manufacturer")]
            public void sendReportToManufacturer()
            {
                //Ha in dbcontext, köra klassen MailingService.
            }
        }
}
