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
        public async void productExport([Option(0)]  string to)
        {

            if(to == "--to=pricerunner")
            {
                HandleJsonFile file = new HandleJsonFile();
                var dbcontext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                file.SetTestProductToDataBaseValues(dbcontext.Products, dbcontext.Categories, dbcontext.Manufacturers);
            }
            await Console.Out.WriteLineAsync("EXPORT FUNKAR");
        }

        //product verifyimage
        [Command("verifyimage", "Displays if image exists.")]
        public async void verifyImage()
        {
            Verifyproduct verifyproduct = new Verifyproduct();

            var dbContext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            Console.WriteLine("checking images...");

            Console.WriteLine("VERIFY IMAGE FUNKAR");

            verifyproduct.ProductVerification(dbContext.Products);

            Thread.Sleep(10000);
            
        }
    }
}
