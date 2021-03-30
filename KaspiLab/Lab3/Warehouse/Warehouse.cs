using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Interfaces;

namespace Lab3
{
    abstract class Warehouse : IWarehouse
    {
        public delegate void WarehouseHandler(object sender, WarehouseEventArgs e);
        public event WarehouseHandler AddCorrectPoduct;
        public event WarehouseHandler AddIncorrectPoduct;

        /// <summary>
        /// 2 метода реализованы для вызова ивентов в наследованных классах
        /// </summary>
        /// <param name="e"></param>
        public void OnAddCorrect(WarehouseEventArgs e)
        {
            WarehouseHandler handler = AddCorrectPoduct;
            handler?.Invoke(this, e);
        }

        public virtual void OnAddIncorrect(WarehouseEventArgs e)
        {
            WarehouseHandler handler = AddIncorrectPoduct;
            handler?.Invoke(this, e);
        }




        public Adress WarehouseAdress { get; protected set; }
        public Employee Worker { get; protected set; }

        public int Square { get; protected set; }
        public Warehouse(Adress adress, int square)
        {
            WarehouseAdress = adress; Square = square;
        }

        public int ProductCount => ProductDict.Sum(x => x.Value);

        public Dictionary<Product, int> ProductDict = new Dictionary<Product, int>();

        public abstract void AddProduct(Product product, int count = 1);
        

        public double Calculate()
        {
            double totalcost = 0;
            foreach (var pr in ProductDict)
            {
                totalcost += pr.Value * pr.Key.Cost;
            }
            return totalcost;
        }

        public void MoveProduct(Product product, Warehouse warehouse, int count = 1)
        {
            if (!ProductDict.ContainsKey(product))
                return;
            if (ProductDict[product] - count < 0)
                throw new Exception("Вы пытаетесь перенести слишком большое кол-во товаров со склада! Столько товаров на складе нет!");
            ProductDict[product] -= count;
            warehouse.AddProduct(product, count);
        }

        public string SearchProductString(string sku)
        {
            
            if (ProductDict.Any(x => x.Key.SKU == sku))
                return ProductDict.Where(x => x.Key.SKU == sku).First().ToString();
            return "Не найдено";

        }


        public bool SearchProduct(Product product)
        {
            return ProductDict.ContainsKey(product);
        }


        public void SetEmployee(Employee emp)
        {
            Worker = emp;
        }


        public override string ToString()
        {
            string type = this is ClosedWarehouse ? "Крытый склад" : "Открытый склад";
            string employee = Worker?.ToString() ?? "Не назначен";
            return $"Адрес склада: {WarehouseAdress.ToString()}, площадь: {Square}. Количество товаров: {ProductCount}. Тип склада: {type} \r\n Ответсвенный сотрудник: {employee}";
        }
    }
}
