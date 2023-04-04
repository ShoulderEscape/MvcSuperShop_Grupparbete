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

        public void SetTestProductToDataBaseValues(IEnumerable<Product> products, IEnumerable<Category> categories, IEnumerable<Manufacturer> manufacturers)
        {
            Faker faker = new Faker();
            List<TestProduct> testProducts = new List<TestProduct>();
            Random rand = new Random();
            ClassForJsonFile ReadyFile = new ClassForJsonFile();

            string categoryname = "";
            string Brand = "";

            foreach (var product in products)
            {
                foreach(var cate in categories)
                {
                    if(product.Category.Id == cate.Id)
                    {
                        categoryname = cate.Name;
                    }
                }
                foreach(var manu in manufacturers)
                {
                    if(product.Manufacturer.Id == manu.Id)
                    {
                        Brand = manu.Name;
                    }
                }

                testProducts.Add(new TestProduct()
                {
                    Id = product.Id,
                    title = product.Name,
                    description = faker.Lorem.Lines(),
                    price = product.BasePrice,
                    discountPercentage = 0.0m,
                    rating = rand.Next(0, 6),
                    stock = rand.Next(0, 100),
                    brand = Brand,
                    category = categoryname,
                    image = product.ImageUrl

                });
            }
            ReadyFile.testProducts = testProducts;
            ReadyFile.total = testProducts.Count;
            ReadyFile.skip = 0;
            ReadyFile.limit = 0;

            string json = JsonSerializer.Serialize(ReadyFile);
            using (StreamWriter sw = new StreamWriter($".\\outfiles\\pricerunner\\{DateTime.Now.Date.ToString("d")}.txt"))
            {
                sw.WriteLine(json);
            }


        }
    }
}
