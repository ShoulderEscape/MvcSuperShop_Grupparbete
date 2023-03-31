using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.Commands
{
    public class Kategori : ConsoleAppBase
    {
        //category checkempty
        [Command("checkempty", "-")]
        public void checkIfEmpty()
        {
            //var categoryValidator = new CategoryValidator();

            ApplicationDbContext dbContext;

            var list = new List<Category>();

            //list = categoryValidator.RunValidor();

            list.ForEach(c => Console.WriteLine(c.Name));

        }
    }
}
