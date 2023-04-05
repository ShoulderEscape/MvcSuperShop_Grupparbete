using Org.BouncyCastle.Security;
using ShopGeneral.Commands;
using ShopGeneral.Data;
using ShopGeneral.JsonHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete_TestArea.JsonFile.Test
{
    [TestClass]
    public class HandleJsonFileTest
    {
        private HandleJsonFile sut;
        List<ShopGeneral.Data.Product> product = new List<ShopGeneral.Data.Product>();
        List<ShopGeneral.Data.Category> category = new List<ShopGeneral.Data.Category>();
        List<ShopGeneral.Data.Manufacturer> manufacturer = new List<ShopGeneral.Data.Manufacturer>();

        [TestInitialize]
        public void Initialize()
        {
            sut = new HandleJsonFile();
            category.Add(new ShopGeneral.Data.Category { Id = 1, Icon = "fin icon", Name = "Bil" });
            category.Add(new ShopGeneral.Data.Category { Id = 2, Icon = "Dålig icon", Name = "Bil" });
            category.Add(new ShopGeneral.Data.Category { Id = 3, Icon = "okej icon", Name = "Bil" });
            manufacturer.Add(new ShopGeneral.Data.Manufacturer { Id = 1, EmailReport = "Ja bilen var okej", Name = "volvo", Icon = category[0].Icon });
            manufacturer.Add(new ShopGeneral.Data.Manufacturer { Id = 2, EmailReport = "bilen var toppen", Name = "toyta", Icon = category[1].Icon });
            manufacturer.Add(new ShopGeneral.Data.Manufacturer { Id = 3, EmailReport = "bilen var fin", Name = "Suzuki", Icon = category[2].Icon });
            product.Add(new ShopGeneral.Data.Product() { Id = 1, AddedUtc = DateTime.Now, BasePrice = 234, Category = category[0], ImageUrl = "a nice image", Name = "bert", Manufacturer = manufacturer[0] });
            product.Add(new ShopGeneral.Data.Product() { Id = 2, AddedUtc = DateTime.Now, BasePrice = 2234, Category = category[1], ImageUrl = "a ugly image", Name = "Olivia", Manufacturer = manufacturer[1] });
            product.Add(new ShopGeneral.Data.Product() { Id = 3, AddedUtc = DateTime.Now, BasePrice = 4234, Category = category[2], ImageUrl = "a intresting image", Name = "martin", Manufacturer = manufacturer[2] });
        }

        [TestMethod]
        public void Check_if_TestProduct_list_is_filled_up()
        {
            sut.SetTestProductToDataBaseValues(product, category, manufacturer);

            Assert.AreEqual(3, sut.ReadyFile.testProducts.Count());
        }

        
    }
}
