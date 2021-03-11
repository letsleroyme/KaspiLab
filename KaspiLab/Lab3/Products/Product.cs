using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class Product
    {
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public abstract double Cost { get; set; }
    }
}
