using Microsoft.EntityFrameworkCore;
using ShopGeneral.CategoryValidator;
using ShopGeneral.Data;
using Microsoft.Data.Sqlite;


namespace MvcSuperShop.CategoryValidatorTest
{

    [TestClass]
    public class CategoryValidatorTest
    {
        private ApplicationDbContext dbContext;
        private Validator sut;
        [TestInitialize]
        public void initilizer()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            dbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options);
            dbContext.Database.EnsureCreated();

            sut = new Validator();
        }
        //public Validator sut = new Validator();

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
            dbContext.AddRange(products);
            dbContext.AddRange(categories);


            dbContext.SaveChanges();

            //Assert.AreEqual(0, sut.RunValidor(dbContext).Count);


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
            dbContext.AddRange(products);
            dbContext.AddRange(categories);
            dbContext.SaveChanges();




            //Assert.AreEqual(1, sut.RunValidor(dbContext.Categories, dbContext.Products).Count);
        }
    }
}