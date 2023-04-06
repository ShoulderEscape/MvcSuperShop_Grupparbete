using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ShopGeneral.Data;
using ShopGeneral.Mailing;

[TestClass]
public class VerifyproductTest
{
    private ApplicationDbContext dbContext;

 [TestInitialize]
    public void Initializer()
    {
        var connection = new SqliteConnection("DataSource=:memory:");
        connection.Open();
        dbContext = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection).Options);
        dbContext.Database.EnsureCreated();


        dbContext.AddRange(new[]
        {
            new Product() { AddedUtc=DateTime.Now, Id=164, BasePrice= 299, ImageUrl="ihsd0rghodrhg"},  
            new Product() {Id=153, ImageUrl="ehweorhgorg"},
            new Product() {Id=143, ImageUrl="ohefoheohgeghs"}
        });

    }
    [TestMethod]
    public void Call_verify_product_method()
    {
        var moq = new Moq.Mock<IVerifyproductValidator>();

        moq.Object.ProductVerification(dbContext.Products);

        moq.Verify(m => m.ProductVerification(dbContext.Products), Moq.Times.Once());
    }
}
