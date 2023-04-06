using Microsoft.EntityFrameworkCore;
using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.CategoryValidator
{
    public class Validator : IValidator
    {
        public Validator() { }
        public void ValidateCategoryData(IEnumerable<Category> categories, IEnumerable<Product> products)
        {
            savefile(RunValidator(categories, products), getfilename());
        }
        public string RunValidator(IEnumerable<Category> categories, IEnumerable<Product> products)
        {
            List<Category> categoriesWithoutProducts = new List<Category>();
            categories.ToList().ForEach( category=> {
                if(!products.Any(product => product.Category == category))
                {
                    categoriesWithoutProducts.Add(category);
                }      
            });
            string str = "";
            categoriesWithoutProducts.ForEach(category => str += $"{category.Name}\n");
            return str;

        }
        
        public void savefile(string str, string filename)
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine(str);
            }
        }
        public string getfilename()
        {
            DateTime now = DateTime.Now;

            string month = "" + now.Month;
            string day = "" + now.Day;
            if (month.Length == 1) month = 0 + month;
            if (day.Length == 1) day = 0 + day;
            string filename = $".\\outfiles\\category\\missingproducts-{now.Year}{month}{day}.txt";
            return filename;

        }
    }
}
