using Moq;
using ShopGeneral.Data;
using ShopGeneral.Mailing;
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
        private Manufacturer manufacturer;
        private MailingService sut;
        //private Moq.Mock sut;

        [TestInitialize]
        public void Initializ() 
        {
            sut = new MailingService();
        }

        //[TestMethod]
        //public void TestToSendMail() 
        //{
        //    manufacturer= new Manufacturer() { Id=1, Name="Test", EmailReport="Test@Test.test", Icon=null };
        //    var moq = new Moq.Mock<MailingService>();
        //    //moq.Setup(m => m.Mail(It.IsAny<Manufacturer>()));

        //    //moq.Object.Mail(manufacturer);

        //    moq.Verify(m => m.Mail(manufacturer), Times.Once());
        //    //moq.VerifyAll();

        //}

        [TestMethod]
        public void TestToSendMail()
        {
            manufacturer = new Manufacturer() { Id = 1, Name = "Test2", EmailReport = "Test@Test.test", Icon = null };

            //sut.Mail(manufacturer);

            
        }

    }
}
