using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;
using Lab3.Interfaces;

namespace Lab3.Warehouse
{
    class OpenWarehouse : Warehouse, IWarehouse
    {
        private List<Product> _products;
        /*public Product[] Products 
        { 
            set
            {
                foreach (var product in Products)
                {
                    if (product is BulkProduct bulkProduct)
                        throw new Exception("На открытом складе не могут храниться сыпучие продукты");
                    _products = Products;
                }
            }

            get
            {
                return _products;
            }
        }*/


        public void AddProduct(Product product)
        {
            if (!(product is BulkProduct))
                _products.Add(product);
        }

        public double Calculate()
        {
            double totalcost = 0;
            foreach (var product in _products)
                totalcost += product.Cost;
            
            return totalcost;
        }

        public Product MoveProduct(Product product)
        {
            _products.Remove(product);
            return product;
        }

        public Product SearchProduct(string sku)
        {
            return _products.Where(x => x.SKU == sku).FirstOrDefault();
        }

        public void SetEmployee(Employee emp)
        {
            base.Manager = emp;
        }



    }
}
