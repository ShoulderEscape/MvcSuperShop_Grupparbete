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
        private MailingService sut;
        //private Moq.Mock sut;

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
                new Manufacturer() { Id=1, EmailReport="Test@Test.se", Icon="", Name="MrX" },
                new Manufacturer() { Id = 2, EmailReport = "Test@Test.com", Icon = "", Name = "MrY" },
                new Manufacturer() { Id = 3, EmailReport = "Test@Test.net", Icon = "", Name = "MrZ" }
            });

        }


        [TestMethod]
        public void Test_To_Send_Mail() 
        {
            var hej = new { product = new { hej = "hej" } };
        }



        //[TestMethod]
        //public void TestToSendMail()
        //{
        //    manufacturer = new Manufacturer() { Id = 1, Name = "Test", EmailReport = "Test@Test.test", Icon = null };
        //    var moq = new Moq.Mock<MailingService>();
        //    //moq.Setup(m => m.Mail(It.IsAny<Manufacturer>()));

        //    //moq.Object.Mail(manufacturer);

        //    moq.Verify(m => m.Mail(manufacturer), Times.Exactly(3));
        //    //moq.VerifyAll();

        //}

        //[TestMethod]
        //public void TestToSendMail()
        //{
        //    manufacturer = new Manufacturer() { Id = 1, Name = "Test2", EmailReport = "Test@Test.test", Icon = null };

        //    sut.Mail(manufacturer);


        //}

    }
}
