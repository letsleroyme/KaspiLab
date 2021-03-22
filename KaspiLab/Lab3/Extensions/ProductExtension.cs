using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    static class ProductExtension
    {
        public static string GetName(this Product product) 
        {
            return $"{product.SKU} - {product.Name}";
        }
    }
}
