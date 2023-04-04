using ShopGeneral.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGeneral.JsonHandler
{
    public class ClassForJsonFile
    {
        public List<TestProduct> testProducts { get; set; } = new List<TestProduct>();
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }
}