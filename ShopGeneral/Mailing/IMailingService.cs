using ShopGeneral.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.Mailing
{
    public interface IMailingService
    {
        public void MailAllManufacturers(IEnumerable<Manufacturer> manufacturers);

    }
}
