using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.JsonHandler
{
    public class TestProduct
    {

        public int Total { get; set; } = 0;
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public decimal discountPercentage { get; set; } 
        public decimal rating { get; set; }
        public int stock { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        [MaxLength(100)]public string image { get; set; }
    }
}
