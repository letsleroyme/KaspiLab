using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;

namespace Lab3
{
    abstract class Warehouse
    {
        public string Adress { get; protected set; }
        public int Square { get; protected set; }
        public Warehouse(string adress, int square)
        {
            Adress = adress; Square = square;
            Products = new List<Product>();
            AddProducttoDict();
        }

        //private int _productCount;
        public int ProductCount => Products.Count;



        public Dictionary<Product, int> ProductDict = new Dictionary<Product, int>();

        protected void AddProducttoDict()
        {
            foreach (var pr in Products)
            {
                if (ProductDict.ContainsKey(pr))
                {
                    ProductDict[pr]++;
                }
                else
                {
                    ProductDict.Add(pr, 1);
                }
            }
        }






        public Employee Worker { get; protected set; }


        protected List<Product> Products { get; set; }
        //public abstract List<Product> Products { get; set; }

        public abstract void AddProduct(Product product);


        public double Calculate()
        {
            double totalcost = 0;
            foreach (var product in Products)
                totalcost += product.Cost;

            return totalcost;
        }

        public void MoveProduct(Product product, Warehouse warehouse, int count = 1)
        {
            if (!Products.Contains(product))
                return;
            for (int i = 0; i < count; i++)
            {
                foreach (var pr in Products.ToList())
                {
                    Products.Remove(product);
                    warehouse.AddProduct(pr);
                }
            }
            AddProducttoDict();

        }

        public string SearchProductString(string sku)
        {
            
            if (!Products.Any(x => x.SKU == sku))
                return "Не найдено";
            return Products.Where(x => x.SKU == sku).FirstOrDefault().ToString();
        }


        public Product SearchProduct(Product product)
        {
            //int productCount = Products.Where(x => x.SKU == sku).Count();
            if (!Products.Contains(product))
                return null;
            return Products.Where(x => x == product).FirstOrDefault();
        }


        public void SetEmployee(Employee emp)
        {
            Worker = emp;
        }


        public override string ToString()
        {
            string type = this is ClosedWarehouse ? "Крытый склад" : "Открытый склад";
            string employee = Worker?.ToString() ?? "Не назначен";
            return $"Адрес склада: {Adress}, площадь: {Square}. Количество товаров: {ProductCount}. Тип склада: {type} \r\n Ответсвенный сотрудник: {employee}";
        }
    }
}
