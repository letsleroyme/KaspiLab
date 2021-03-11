using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;
using Lab3.Interfaces;

namespace Lab3.Warehouse
{
    class ClosedWarehouse : Warehouse
    {
        //private List<Product> _products;
        //public override List<Product> Products { get => _products; set => _products = value; }

        public override void AddProduct(Product product)
        {
            base.Products.Add(product); 
        }
    }
}
