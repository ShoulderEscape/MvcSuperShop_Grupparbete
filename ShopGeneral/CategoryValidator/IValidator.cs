using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.CategoryValidator
{
    public interface IValidator
    {
        public void ValidateCategoryData(IEnumerable<Category> categories, IEnumerable<Product> products);
        public string RunValidator(IEnumerable<Category> categories, IEnumerable<Product> products);
        public void savefile(string str, string filename);
        public string getfilename();


    }
}
