using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ShopGeneral.Data;
using ShopGeneral.Mailing;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
namespace Grupparbete_TestArea.Verifyprod.Test 
{
    [TestClass]
    public class VerifyproductTest
    {
        private ApplicationDbContext dbContext;
        private List<string> errorlist;
        private IVerifyproductValidator sut;

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

            errorlist = new List<string>();
            errorlist.AddRange(new[]
            {
            "hello", "hiohrgorg", "rhgorhg", "ehoerhhrg", "oheohef"
        });


        }
        [TestMethod]
        public void Call_verify_product_method()
        {
            var moq = new Moq.Mock<IVerifyproductValidator>();

            moq.Object.Writetofile(errorlist);

            moq.Verify(m => m.Writetofile(errorlist), Moq.Times.Once());
        }

    
        

          
        
    }
}

