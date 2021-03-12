using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;
using Lab3.Interfaces;

namespace Lab3
{
    class OpenWarehouse : Warehouse
    {
        public OpenWarehouse(string adress, int square) : base(adress, square)
        {

        }


        public override void AddProduct(Product product)
        {
            if (!(product is BulkProduct))
            {
                Products.Add(product);
                AddProducttoDict();

            }

        }



    }
}
