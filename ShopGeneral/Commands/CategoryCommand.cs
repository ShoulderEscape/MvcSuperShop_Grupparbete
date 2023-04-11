using Microsoft.Extensions.DependencyInjection;
using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopGeneral.CategoryValidator;

namespace ShopGeneral.Commands
{

    [Command("category")]
    public class CategoryCommand : ConsoleAppBase
    {
        //category checkempty
        [Command("checkempty", "Checking if categorys are emtpty.")]
        public async void checkIfEmpty()
        {
            var validator = new Validator();


            ApplicationDbContext dbContext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();


            validator.RunValidor(dbContext.Categories, dbContext.Products);

            Console.WriteLine("Validating that all categories contains products");

            validator.ValidateCategoryData(dbContext.Categories, dbContext.Products);
            
            Console.WriteLine("DONE");


        }
    }
}
