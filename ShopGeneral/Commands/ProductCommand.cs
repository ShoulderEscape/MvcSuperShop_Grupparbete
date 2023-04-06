using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509;
using ShopGeneral.Data;
using ShopGeneral.JsonHandler;
using System.Runtime.InteropServices;

namespace ShopGeneral.Commands
{


    [Command("product")]
    public class PorductCommand : ConsoleAppBase
    {

        //product export --to=pricerunner
        [Command("export", "Exports product to file.")]
        public void ProductExport([Option(0)]  string to)
        {

            Console.WriteLine("Creating file for Pricerunner...");

            if (to == "--to=pricerunner")
            {
                HandleJsonFile file = new HandleJsonFile();
                var dbcontext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                file.SetTestProductToDataBaseValues(dbcontext.Products, dbcontext.Categories, dbcontext.Manufacturers);
            }

            Console.WriteLine("DONE");
            
        }

        //product verifyimage
        [Command("verifyimage", "Displays if image exists.")]
        public void VerifyImage()
        {
            Verifyproduct verifyproduct = new Verifyproduct();

            var dbContext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        
            Console.WriteLine("checking images...");

            verifyproduct.VerifyproductMain(dbContext.Products);

           
        }
    }
}

