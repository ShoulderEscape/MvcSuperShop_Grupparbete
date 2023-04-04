using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509;
using ShopGeneral.Data;
using ShopGeneral.JsonHandler;
using System.Runtime.InteropServices;

namespace ShopGeneral.Commands
{
    public class Product : ConsoleAppBase
    {
        //product export --to=pricerunner
        [Command("export", "Exports product to file.")]
        public void productExport([Option(0)] string to)
        {

            if(to == "--to=pricerunner")
            {
                HandleJsonFile file = new HandleJsonFile();
                var dbcontext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                file.SetTestProductToDataBaseValues(dbcontext.Products, dbcontext.Categories, dbcontext.Manufacturers);
            }
        }

        //product verifyimage
        [Command("verifyimage", "Displays if image exists.")]
        public void verifyImage(string msg = "2")
        {
            Verifyproduct verifyproduct = new Verifyproduct();

            var dbContext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Console.WriteLine("checking images...");

            verifyproduct.ProductVerification(dbContext.Products);

            Thread.Sleep(10000);
        }
    }
}
