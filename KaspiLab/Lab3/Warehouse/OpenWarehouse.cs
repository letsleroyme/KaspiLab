using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;
using Lab3.Interfaces;

namespace Lab3.Warehouse
{
    class OpenWarehouse : Warehouse
    {
        private List<Product> _products;
        
        public override List<Product> Products
        { 
            set
            {
                foreach (var product in Products)
                {
                    if (product is BulkProduct bulkProduct)
                        throw new Exception("На открытом складе не могут храниться сыпучие продукты!");
                    _products = value;
                }
            }

            get
            {
                return _products;
            }
        }


        public override void AddProduct(Product product)
        {
            if (!(product is BulkProduct))
                _products.Add(product);
        }



    }
}
