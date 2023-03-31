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
    public class Commands
    {
        public class Product : ConsoleAppBase
        {

            // echo --msg <String>
            [Command("echo", "--msg")]
            public void Echo(string msg  ="hejsant")
            {
                Console.WriteLine(msg);
            }
            //--sum <int x> <int y>
            [Command("--sum", "x, y")]
            public void Sum([Option(0)] int x, [Option(1)] int y)
            {
                Console.WriteLine((x + y).ToString());
            }

            //product export --to=pricerunner
            [Command("export --to = pricerunner", "Exports product to file.")]
            public void productExport(string msg = "1")
            {
                Console.WriteLine(msg + "PRODUCTEXPORT");
            }

            //product verifyimage
            [Command("verifyimage", "Displays if image exists.")]
            public void verifyImage(string msg = "2")
            {
                Console.WriteLine(msg + "VERIFYIMAGE");
            }
        }

        public class Kategori : ConsoleAppBase
        {
            

            //category checkempty
            [Command("checkempty", "-")]
            public void checkIfEmpty()
            {
                var categoryValidator = new CategoryValidator();

                ApplicationDbContext dbContext;

                var list = new List<Category>();

                //list = categoryValidator.RunValidor();

                list.ForEach(c => Console.WriteLine(c.Name));

            }
        }

        public class Manufacturer : ConsoleAppBase
        {
            //manufacturer sendreport
            [Command("sendreport", "sends report to manufacturer")]
            public void sendReportToManufacturer(string msg = "4")
            {
                Console.WriteLine(msg + "MANUFACTURER REPORT");
            }
        }
    }
}
