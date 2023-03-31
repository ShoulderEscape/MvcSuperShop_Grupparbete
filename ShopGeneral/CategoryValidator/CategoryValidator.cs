using Microsoft.EntityFrameworkCore;
using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.CategoryValidator
{
    public class CategoryValidator
    {
        public CategoryValidator() { }
        public List<Category> RunValidor(ApplicationDbContext dbContext)
        {
            List<Category> categories = new List<Category>();
            dbContext.Categories.ToList().ForEach( category=> {
                if(!dbContext.Products.Any(product => product.Category == category))
                {
                    categories.Add(category);
                }      
            });
            string str = "";
            categories.ForEach(category => str += $"{category.Name}\n");

            //savefile(str,getfilename());
            return categories;
        }
        public void savefile(string str, string filename)
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
               
            File.AppendAllText(filename, str);
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
