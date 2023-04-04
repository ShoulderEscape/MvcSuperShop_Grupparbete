using Bogus;
using Bogus.DataSets;
using ShopGeneral.Data;
using ShopGeneral.Infrastructure.Context;
using ShopGeneral.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopGeneral.JsonHandler
{
    public class HandleJsonFile
    {
        public void SetProductInJsonFile(IEnumerator<Product> product)
        {
            
            string json = JsonSerializer.Serialize(product);

            File.WriteAllText(@"C:\Users\isakz\OneDrive\Skrivbord\TUC SkolMap\Programmering fördjupning\MvcSuperShop_Grupparbete\ShopGeneral\JsonHandler\ProductToAdd.json", json);


            //Console.WriteLine("input command");
            //string input = Console.ReadLine();



            //if(input == "product export --to=pricerunner")
            //{
            //    TestProduct product1 = new TestProduct()
            //    {
            //        Id = 1,
            //        title = "Iphone 9",
            //        description = "Ann apple mobile which is nothing like apple",
            //        price = 599,
            //        discountPercentage = new decimal(12.42),
            //        rating = new decimal(4.69),
            //        stock = 45,
            //        brand = "Apple",
            //        category = "smartphones",
            //        images = new List<string>() { "fsf", "hmhmh" }
            //    };
            //    string json = JsonSerializer.Serialize(product1);
            //    File.WriteAllText(@"C:\Users\isakz\OneDrive\Skrivbord\TUC SkolMap\Programmering fördjupning\MvcSuperShop_Grupparbete\ShopGeneral\JsonHandler\ProductToAdd.json", json);
            //}
        }


    }
}
