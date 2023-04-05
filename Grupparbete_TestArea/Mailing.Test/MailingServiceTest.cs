using MailKit;
using MailKit.Net.Smtp;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using ShopGeneral.Data;
using ShopGeneral.Mailing;
using ShopGeneral.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupparbete_TestArea.Mailing.Test
{
    [TestClass]
    public class MailingServiceTest
    {
        private ApplicationDbContext dbContext;

        [TestInitialize]
        public void Initializ() 
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            dbContext = new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options);
            dbContext.Database.EnsureCreated();

            dbContext.Manufacturers.AddRange(new[] 
            { 
                new Manufacturer() { Id = 1, EmailReport="Test@Test.se", Icon="", Name="MrX" },
                new Manufacturer() { Id = 2, EmailReport = "Test@Test.com", Icon = "", Name = "MrY" },
                new Manufacturer() { Id = 3, EmailReport = "Test@Test.net", Icon = "", Name = "MrZ" }
            });

            dbContext.SaveChanges();

        }


        [TestMethod]
        public void TestToSendMail()
        {
            var moq = new Moq.Mock<IMailingService>();

            moq.Object.MailAllManufacturers(dbContext.Manufacturers);

            moq.Verify(m => m.MailAllManufacturers(dbContext.Manufacturers),Times.Once());

        }

    }
}
