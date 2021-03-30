using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class AllProducts
    {
        private AllProducts() { }
        private static readonly object _lock = new object();

        private static AllProducts _instance;
        public static AllProducts GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AllProducts();
                    }
                }
            }
            return _instance;

        }

        public Dictionary<Product, int> Products = new Dictionary<Product, int>();

        public void AddProduct(Product product, int count = 1)
        {
            if (!Products.ContainsKey(product))
            {
                Products.Add(product, count);
            }
            else
            {
                Products[product] += count;
            }
        }

    }
}
