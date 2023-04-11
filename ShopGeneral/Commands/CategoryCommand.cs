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
    public class Kategori : ConsoleAppBase
    {
        //category checkempty
        [Command("checkempty", "-")]
        public void checkIfEmpty()
        {
            var validator = new Validator();


            ApplicationDbContext dbContext = Context.ServiceProvider.GetRequiredService<ApplicationDbContext>();


            validator.RunValidor(dbContext.Categories, dbContext.Products);


        }
    }
}
