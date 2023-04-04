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

        public void SetTestProductToDataBaseValues(IEnumerable<Product> products)
        {
            Faker faker = new Faker();
            List<TestProduct> testProducts = new List<TestProduct>();
            Random rand = new Random();
            ClassForJsonFile ReadyFile = new ClassForJsonFile();
            foreach (var product in products)
            {
                testProducts.Add(new TestProduct()
                {
                    Id = product.Id,
                    title = product.Name,
                    description = faker.Lorem.ToString(),
                    price = product.BasePrice,
                    discountPercentage = 0.0m,
                    rating = rand.Next(0, 6),
                    stock = rand.Next(0, 100),
                    brand = product.Manufacturer.Name,
                    category = product.Category.Name,
                    image = product.ImageUrl

                });
            }
            ReadyFile.testProducts = testProducts;
            ReadyFile.total = testProducts.Count;
            ReadyFile.skip = 0;
            ReadyFile.limit = 0;

            string json = JsonSerializer.Serialize(ReadyFile);
            File.WriteAllText(".\\outfile\\pricerunner\\" + DateTime.Now + ".txt", json);
        }
    }
}
