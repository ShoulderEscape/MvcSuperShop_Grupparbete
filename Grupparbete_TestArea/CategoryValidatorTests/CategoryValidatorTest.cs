using Microsoft.EntityFrameworkCore;
using ShopGeneral.CategoryValidator;
using ShopGeneral.Data;
using Microsoft.Data.Sqlite;
using Moq;

namespace MvcSuperShop.CategoryValidatorTest
{

    [TestClass]
    public class CategoryValidatorTest
    {
        private Validator sut = new Validator();
     
        [TestMethod]
        public void Validate_No_Errors_in_project_if_all_categories_have_products()
        {
            var products = new List<Product>();
            var categories = new List<Category>();
            categories.Add(new Category
            {
                Id = 1,
                Name = "Car",
                Icon = "icon"
            });
            categories.Add(new Category
            {
                Id = 2,
                Name = "Food",
                Icon = "Icon2"
            });
            products.Add(new Product
            {
                Id = 1,
                Name = "Volvo V70",
                Category = categories[0],
                Manufacturer = new Manufacturer
                {
                    Id = 1,
                    Name = "Volvo",
                    Icon = "Icon3",
                    EmailReport = "email@email.com"
                },
                BasePrice = 10,
                AddedUtc = new DateTime(2000, 10, 5),
                ImageUrl = "image"
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Icecream sandwich",
                Category = categories[1],
                Manufacturer = new Manufacturer
                {
                    Id = 2,
                    Name = "Mercedez benz",
                    Icon = "Icon4",
                    EmailReport = "email@email.se"
                },
                BasePrice = 100,
                AddedUtc = new DateTime(2001, 10, 5),
                ImageUrl = "image2"
            });
            string expectedValue = "";



           Assert.AreEqual(expectedValue, sut.RunValidator(categories, products));



        }
        
        [TestMethod]
        public void Validate_That_The_Return_of_Validate_categories_will_be_correct_if_there_are_categories_without_a_product()
        {
            var products = new List<Product>();
            var categories = new List<Category>();
            categories.Add(new Category
            {
                Id = 1,
                Name = "Car",
                Icon = "icon"
            });
            categories.Add(new Category
            {
                Id = 2,
                Name = "Food",
                Icon = "Icon2"
            });
            products.Add(new Product
            {
                Id = 1,
                Name = "Volvo V70",
                Category = categories[0],
                Manufacturer = new Manufacturer
                {
                    Id = 1,
                    Name = "Volvo",
                    Icon = "Icon3",
                    EmailReport = "email@email.com"
                },
                BasePrice = 10,
                AddedUtc = new DateTime(2000, 10, 5),
                ImageUrl = "image"
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Icecream sandwich",
                Category = categories[0],
                Manufacturer = new Manufacturer
                {
                    Id = 2,
                    Name = "Mercedez benz",
                    Icon = "Icon4",
                    EmailReport = "email@email.se"
                },
                BasePrice = 100,
                AddedUtc = new DateTime(2001, 10, 5),
                ImageUrl = "image2"
            });


            string expectedValue = $"{categories[1].Name}\n";


           Assert.AreEqual(expectedValue, sut.RunValidator(categories, products));

        }
        
        [TestMethod]
        public void check_if_RunValidator_is_called()
        {
            var moq = new Mock<IValidator>();
            var categories = new List<Category>();
            var products = new List<Product>();
            moq.Object.RunValidator(categories, products);

            moq.Verify(m => m.RunValidator(categories, products), Times.Once());
        }
        [TestMethod]
        public void check_if_GetFileName_returns_the_correct_filename()
        {
            DateTime now = DateTime.Now;

            string month = "" + now.Month;
            string day = "" + now.Day;
            if (month.Length == 1) month = 0 + month;
            if (day.Length == 1) day = 0 + day;
            string filename = $".\\outfiles\\category\\missingproducts-{now.Year}{month}{day}.txt";


            Assert.AreEqual(sut.getfilename(), filename);

        }
    }
}
