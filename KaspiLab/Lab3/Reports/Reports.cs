using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;

namespace Lab3
{
    static class Reports
    {
        /// <summary>
        /// перечень товаров, количество которых меньше 3. вывод отсортирован по возрастанию количества
        /// </summary>
        /// <param name="warehouse">Склад</param>
        /// <returns>Перечень товаров</returns>
        public static Dictionary<Product, int> ProductsLessThan3(Warehouse warehouse)
        {
            return warehouse.ProductDict.Where(x => x.Value < 3).OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }
        /// <summary>
        /// список уникальных наименований товаров на складе (сортировка по ноименованию)
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public static Dictionary<Product, int> UniqueProducts(Warehouse warehouse)
        {
            return warehouse.ProductDict.Distinct().ToDictionary(x => x.Key, x => x.Value);
        }
        /// <summary>
        ///  первые 3 товара в наибольшем количестве на складе
        /// </summary>
        /// <param name="warehouse"></param>
        /// <returns></returns>
        public static Dictionary<Product, int> Top3ProductCount(Warehouse warehouse)
        {
            return warehouse.ProductDict.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
        }
        /// <summary>
        ///  список складов, на которых нет сыпучих продуктов
        /// </summary>
        /// <param name="warehouses"></param>
        /// <returns></returns>
        public static List<Warehouse> GetWarehouseNoBulkProducts(List<Warehouse> warehouses)
        {
            return warehouses.Select(x => x).OfType<ClosedWarehouse>().Cast<Warehouse>().ToList();
            
        }
        /// <summary>
        ///  список складов, на которых нет жидких продуктов
        /// </summary>
        /// <param name="warehouses"></param>
        /// <returns></returns>
        public static List<Warehouse> GetWarehouseNoLiquidProducts(List<Warehouse> warehouses)
        {
            bool isStop = false;
            var res = new List<Warehouse>();
            foreach (var warehouse in warehouses)
            {
                foreach (var product in warehouse.ProductDict.Keys)
                {
                    if (product is LiquidProduct)
                    {
                        isStop = true;
                        break;
                    }
                }
                if (isStop)
                    res.Add(warehouse);
                isStop = false;
            }
            return res;
        }

        /// <summary>
        /// среднее количество товара на всех складах, в формате товар - среднее количество
        /// </summary>
        /// <param name="warehouses"></param>
        /// <returns></returns>
        public static Dictionary<Product, double> AvarageProduct(List<Warehouse> warehouses)
        { 
            return warehouses
                .SelectMany(x => x.ProductDict)
                .GroupBy(k => k.Key)
                .ToDictionary(g => g.Key, g => g.Average(k => k.Value));
        }



    }
}
