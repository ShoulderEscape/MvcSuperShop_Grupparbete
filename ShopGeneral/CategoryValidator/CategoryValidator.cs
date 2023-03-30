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
            return categories;
        }
    }
}
