using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.Commands
{
    public class Product : ConsoleAppBase
    {
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
}
