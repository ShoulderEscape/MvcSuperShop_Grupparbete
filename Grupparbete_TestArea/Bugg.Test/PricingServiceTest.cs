using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ShopGeneral.Data;
using ShopGeneral.Infrastructure.Context;
using ShopGeneral.Services;
using System.Xml.Linq;

namespace Grupparbete_TestArea.Bugg.Test
{
    [TestClass]
    public class PricingServiceTest
    {
        private ApplicationDbContext dbContext;
        private PricingService sut;

        [TestInitialize]
        public void Initializer()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            dbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(connection)
                .Options);
            dbContext.Database.EnsureCreated();
            sut = new PricingService(dbContext);
        }

        [TestMethod]
        public void CalculatePrices_should_return_product_with_highest_discount()
        {
            var products = new List<ProductServiceModel>();
            var customer = new CurrentCustomerContext();
            Agreement agreement = new Agreement();
            var agreementRows = new List<AgreementRow>();

            agreement.AgreementRows = new List<AgreementRow>();
            customer.Agreements = new List<Agreement>();

            products.Add(new ProductServiceModel
            {
                BasePrice = 1500,
                Price = 1200,
                Name = "Test",
                CategoryName = "Test",
                ManufacturerName = "Test"
            });
            

            agreement.AgreementRows.Add(new AgreementRow
            {
                ProductMatch = "Test",
                CategoryMatch = "Test",
                ManufacturerMatch = "Test",
                PercentageDiscount = 20.0m
            });

            customer.Agreements.Add(agreement);

            var listWithResult = sut.CalculatePrices(products, customer);

            var result = listWithResult.First().Price;

            Assert.AreEqual(1200, result);

        }
    }
}
