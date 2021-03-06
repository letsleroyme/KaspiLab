using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using NLog;
namespace Lab3
{
    class Program
    {

        static object locker = new object();
        static async Task Main(string[] args)
        {
            Logger log = LogManager.GetCurrentClassLogger();

            Invoker AddCommandQueue = new Invoker();
            AddCommandQueue.QueueAdd += QueueEventEncounter;
            AddCommandQueue.QueueExecute += QueueEventEncounter;
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
            AddAllProductsToSingleton(new List<Product>(products));
            
            foreach(var ware in warehouses)
            {
                ware.AddCorrectPoduct += ShowMsg;
                ware.AddIncorrectPoduct += ShowMsg; 
            }


            //async test

            var result = await Reports.GetWarehouseNoBulkProductsAsync(new List<Warehouse>(warehouses)).ConfigureAwait(false);

            
            // async test end

            try 
            {
                /*CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationToken token = cancellationTokenSource.Token;
                AllProducts productsSingletone = AllProducts.GetInstance();
                //Task TaskAdd = new Task(() => AddToQueue(new List<Warehouse>(warehouses), AddCommandQueue));
                Task TasAdd = Task.Factory.StartNew(() => AddToQueue(new List<Warehouse>(warehouses), AddCommandQueue), token);
                Task TaskQueueProcessing = new Task(() => ProcessQueue(AddCommandQueue));
                TaskQueueProcessing.Start();
                */


                /*foreach (var ware in warehouses)
                {
                    AddCommandQueue.SetCommand(new CommandAdd(products[1], ware, 1));

                    ware.AddCorrectPoduct += ShowMsg;
                    ware.AddIncorrectPoduct += ShowMsg;
                    ware.AddIncorrectPoduct += ShowMsg2;
                    //ware.AddProduct(productsSingletone.Products.Keys.ElementAt(1), 10);
                    //ware.AddProduct(productsSingletone.Products.Keys.ElementAt(3), 200);

                    /*int i = 1;
                    foreach(var product in products)
                    {
                        ware.AddProduct(product, i);
                        i++;
                    }
                    Console.WriteLine($"Количество продуктов на складе: {ware.ProductCount}");
                    //ware.AddCorrectPoduct -= ShowMsg;
                    //ware.AddIncorrectPoduct -= ShowMsg2;

                }*/

                /*AddCommandQueue.AddProduct();
                AddCommandQueue.AddProduct();
                AddCommandQueue.AddProduct();
                AddCommandQueue.AddProduct();*/



                // warehouses[0].MoveProduct(products[0], warehouses[2]);
                //double totalcost = 0.0;

                /*foreach (var ware in warehouses)
                {
                    Console.WriteLine($"Количество продуктов на складе: {ware.ProductCount}");
                    Console.WriteLine(ware.ToString());
                    totalcost += ware.Calculate();
                }
                Console.WriteLine(warehouses[0].SearchProductString("010"));

                Console.WriteLine($"Сумма всех товаров на складе: {warehouses[0].Calculate()}");

                //warehouses[1].MoveProduct(products[3], warehouses[2], 3);


                Console.WriteLine(warehouses[0].ToString());
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(warehouses[2].ToString());

                Console.WriteLine(GetWarehouse(new List<Warehouse>(warehouses), products[0], 1)?.ToString() ?? "Склад не найден");

                Console.WriteLine($"Итоговое стоимость всех товаров на всех складах: {totalcost}");

                foreach (var res in Reports.AvarageProduct(new List<Warehouse>(warehouses)))
                {
                    Console.WriteLine($"{res.Key} - {res.Value}");
                }
                
                
                
                
                
                
                Csv.CsvWrite(warehouses[0], @".\files\");
                

                //TaskQueueProcessing.Wait();

                //Task.WaitAll();
                /*foreach (var res in result)
                {
                    Console.WriteLine($"{res.ToString()}");
                }*/


                //GetAllClassesInGeneric();

                GetAllStringInterfaces();
                Csv.WriteAllProducts(@".\files\"); 
            }
            catch (Exception ex)
            {
                log.Debug(ex.ToString() + "\r\n" + ex.StackTrace);
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }


            Console.ReadKey();
            
        }



        public static Warehouse GetWarehouse(List<Warehouse> warehouses, Product product, int count = 1)
        {
            foreach (var ware in warehouses)
            {
                if (ware.ProductDict.ContainsKey(product) && ware.ProductDict.Values.Select(x=>x >= count).FirstOrDefault())
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

        public static void QueueEventEncounter(object sender, CommandQueueEventArgs e)
        {
            Console.WriteLine($"{e.CommandStatus} - {e.CommandTime}");
        }


        public static void AddAllProductsToSingleton(List<Product> prod)
        {
            AllProducts products = AllProducts.GetInstance();

            foreach (var pr in prod)
                products.AddProduct(pr);
        }

        public static void AddToQueue(List<Warehouse> warehouses, Invoker queue)
        {
            AllProducts products = AllProducts.GetInstance();
            foreach (var ware in warehouses)
            {
                lock (locker)
                {
                    queue.SetCommand(new CommandAdd(products.Products.Keys.ElementAt(3), ware, 1));
                }
            }
        }

        public static void ProcessQueue(Invoker queue)
        {
            lock (locker)
            {
                while (queue.CheckQueueForNull())
                {
                    queue.AddProduct();
                }
            }
        }



        public static Dictionary<Product, int> GetUnionProducts(List<Warehouse> warehouses)
        {
            var res = new Dictionary<Product, int>();
            foreach (var warehouse in warehouses)
            {
                foreach (var ware in warehouse.ProductDict)
                {
                    if (!res.ContainsKey(ware.Key))
                        res.Add(ware.Key, ware.Value);
                    else
                        res[ware.Key] += ware.Value;
                }
            }

            return res;
        }


        public static void MoveHalfOfProducts(Warehouse warehouse1, Warehouse warehouse2)
        {
            foreach (var ware in warehouse1.ProductDict)
            {
                if (ware.Value > 1) 
                {
                    warehouse1.MoveProduct(ware.Key, warehouse2, ware.Value / 2);
                }
            }
            
        }


        public static void GetAllClassesInGeneric()
        {
            var e = AppDomain.CurrentDomain.GetAssemblies()
                       .SelectMany(t => t.GetTypes())
                       .Where(t => t.IsClass && t.Namespace == "System.Collections.Generic");
            e.ToList().ForEach(t => Console.WriteLine(t.Name));
        }


        public static void GetAllStringInterfaces()
        {
            var res = typeof(string).GetInterfaces().ToList();
            res.ToList().ForEach(t => Console.WriteLine(t.Name));
        }


    }
}
