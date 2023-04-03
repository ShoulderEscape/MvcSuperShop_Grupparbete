using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509;
using ShopGeneral.Data;

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
            Verifyproduct verifyproduct = new Verifyproduct();

            var dbContext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Console.WriteLine("checking images...");

            verifyproduct.ProductVerification(dbContext.Products);

            Thread.Sleep(10000);
        }
    }
}
