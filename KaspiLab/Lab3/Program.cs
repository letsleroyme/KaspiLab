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

            var adress1 = new Adress("Страна1", "Район1", "Город1", "Улица1", "1");
            var adress2 = new Adress("Страна2", "Район2", "Город2", "Улица2", "2");
            var adress3 = new Adress("Страна3", "Район3", "Город3", "Улица3", "3");
            var adress4 = new Adress("Страна4", "Район4", "Город4", "Улица4", "4");


            warehouses[0] = new ClosedWarehouse(adress1, 100);
            warehouses[1] = new ClosedWarehouse(adress2, 90);
            warehouses[2] = new OpenWarehouse(adress3, 80);
            warehouses[3] = new OpenWarehouse(adress4, 70);

            warehouses[0].SetEmployee(emp1);
            warehouses[1].SetEmployee(emp2);
            warehouses[2].SetEmployee(emp3);

            Product[] products = new Product[5];
            products[0] = new BulkProduct("Песок", "001", "Речной песок", 1.00);
            products[1] = new PieceProduct("Бочка", "002", "Описание", 2.00);
            products[2] = new LiquidProduct("Нефть", "003", "Баррель нефти", 3.00);
            products[3] = new DimensionalProduct("Тонна металаа", "004", "Описание", 4.00);
            products[4] = new BulkProduct("Гравий", "005", "Описание", 5.00);
            try 
            { 
                foreach (var ware in warehouses)
                {
                    ware.AddCorrectPoduct += ShowMsg;
                    ware.AddIncorrectPoduct += ShowMsg;
                    ware.AddIncorrectPoduct += ShowMsg2;
                    ware.AddProduct(products[1], 10);
                    ware.AddProduct(products[3], 200);

                    /*int i = 1;
                    foreach(var product in products)
                    {
                        ware.AddProduct(product, i);
                        i++;
                    }
                    Console.WriteLine($"Количество продуктов на складе: {ware.ProductCount}");*/
                    ware.AddCorrectPoduct -= ShowMsg;
                    ware.AddIncorrectPoduct -= ShowMsg2;

                }

                warehouses[0].AddProduct(products[0], 10);
                warehouses[2].AddProduct(products[3], 200);
                warehouses[3].AddProduct(products[4], 200);



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

                warehouses[1].MoveProduct(products[3], warehouses[2], 3);


                Console.WriteLine(warehouses[0].ToString());
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(warehouses[2].ToString());

                Console.WriteLine(GetWarehouse(new List<Warehouse>(warehouses), products[0], 1)?.ToString() ?? "Склад не найден");

                Console.WriteLine($"Итоговое стоимость всех товаров на всех складах: {totalcost}");


                Console.ReadKey();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }



        }

        private static void Ware_AddCorrectPoduct(object sender, WarehouseEventArgs e)
        {
            throw new NotImplementedException();
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

        public static void ShowMsg(object sender, WarehouseEventArgs e)
        {
            Console.WriteLine($"Добавление на склад: {e.WarehouseName}, тип события: {e.TypeOfEvent}, товар: {e.ProductName}, дата: {e?.Time.ToString()}");
        }

        public static void ShowMsg2(object sender, WarehouseEventArgs e)
        {
            Console.WriteLine("!!! ОБРАБОТЧИК 2  !!!");
        }


    }
}
