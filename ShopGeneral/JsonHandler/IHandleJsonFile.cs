using Bogus;
using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopGeneral.JsonHandler
{
    public interface IHandleJsonFile
    {
        public void SetTestProductToDataBaseValues(IEnumerable<Product> products, IEnumerable<Category> categories, IEnumerable<Manufacturer> manufacturers);

        public void SaveDownDataToFile();

        public void RunBothMethods(IEnumerable<Product> products, IEnumerable<Category> categories, IEnumerable<Manufacturer> manufacturers);
    }
}
