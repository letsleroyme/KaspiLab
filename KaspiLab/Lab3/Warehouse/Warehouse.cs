using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;

namespace Lab3.Warehouse
{
    abstract class Warehouse
    {
        public string Adress;
        public int Square;
        //private int _productCount;
        public int ProductCount
        {
            get => _products.Count;
        }

        public Employee Worker;

        private List<Product> _products;
        public abstract List<Product> Products { get; set; }

        public abstract void AddProduct(Product product);


        public double Calculate()
        {
            double totalcost = 0;
            foreach (var product in _products)
                totalcost += product.Cost;

            return totalcost;
        }

        public void MoveProduct(List<Product> products, Warehouse warehouse)
        {
            foreach (var pr in _products)
            {
                _products.Remove(products.Where(x => x == pr).FirstOrDefault());
                warehouse.AddProduct(pr);
            }
        }

        public Product SearchProduct(string sku)
        {
            return _products.Where(x => x.SKU == sku).FirstOrDefault();
        }

        public void SetEmployee(Employee emp)
        {
            Worker = emp;
        }

        public Warehouse SearchWareHouse()
        {
            return this;
        }


    }
}
