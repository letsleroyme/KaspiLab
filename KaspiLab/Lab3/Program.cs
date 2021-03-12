using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lab3.Products;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Иван Иванович Иванов", "Зав. складом");
            Employee emp2 = new Employee("Петр Петрович Петров", "Управляющий");
            Employee emp3 = new Employee("Александр Александрович Александров", "Старший складской рабочий");

            Warehouse[] warehouses = new Warehouse[4];
            
            warehouses[0] = new ClosedWarehouse("ул. Иванова", 100);
            warehouses[1] = new ClosedWarehouse("ул. Петрова", 90);
            warehouses[2] = new OpenWarehouse("ул. Никитина", 80);
            warehouses[3] = new OpenWarehouse("ул. Васильева", 70);

            warehouses[0].SetEmployee(emp1);
            warehouses[1].SetEmployee(emp2);
            warehouses[2].SetEmployee(emp3);

            Product[] products = new Product[5];
            products[0] = new BulkProduct("Песок", "001", "Речной песок", 1.00);
            products[1] = new PieceProduct("Бочка", "002", "Описание", 2.00);
            products[2] = new LiquidProduct("Нефть", "003", "Баррель нефти", 3.00);
            products[3] = new DimensionalProduct("Тонна металаа", "004", "Описание", 4.00);
            products[4] = new BulkProduct("Гравий", "005", "Описание", 5.00);
            foreach(var ware in warehouses)
            {
                foreach(var product in products)
                {
                    ware.AddProduct(product);
                }
                Console.WriteLine($"Количество продуктов на складе: {ware.ProductCount}");
            }

            warehouses[0].MoveProduct(products[0], warehouses[2]);
            double totalcost = 0.0;

            foreach (var ware in warehouses)
            {
                Console.WriteLine($"Количество продуктов на складе: {ware.ProductCount}");
                Console.WriteLine(ware.ToString());
                totalcost += ware.Calculate();
            }
            Console.WriteLine(warehouses[0].SearchProductString("010"));

            Console.WriteLine($"Сумма всех товаров на складе: {warehouses[0].Calculate()}");

            warehouses[0].MoveProduct(products[0], warehouses[2], 11);


            Console.WriteLine(warehouses[0].ToString());
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(warehouses[2].ToString());

            Console.WriteLine(GetWarehouse(new List<Warehouse>(warehouses), products[0], 1)?.ToString() ?? "Склад не найден");

            Console.WriteLine($"Итоговое стоимость всех товаров на всех складах: {totalcost}");


            Console.ReadKey();






        }
        public static Warehouse GetWarehouse(List<Warehouse> warehouses, Product product, int count = 1)
        {
            foreach (var ware in warehouses)
            {
                if (ware.ProductDict.ContainsKey(product) && ware.ProductDict.ContainsValue(count))
                    return ware;
            }
            return null;
        }
    }
}
