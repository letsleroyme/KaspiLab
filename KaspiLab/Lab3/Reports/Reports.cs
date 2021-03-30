using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public static async Task<Dictionary<Product, int>> ProductsLessThan3Async(Warehouse warehouse)
        {
             return await Task.Run(()=> ProductsLessThan3(warehouse));
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

        public static async Task<Dictionary<Product, int>> UniqueProductsAsync(Warehouse warehouse)
        {
            return await Task.Run(() => UniqueProducts(warehouse));
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

        public static async Task<Dictionary<Product, int>> Top3ProductCountAsync(Warehouse warehouse)
        {
            return await Task.Run(() => Top3ProductCount(warehouse));
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

        public static async Task<List<Warehouse>> GetWarehouseNoBulkProductsAsync(List<Warehouse> warehouses)
        {
            return await Task.Run(() => GetWarehouseNoBulkProducts(warehouses));
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

        public static async Task<List<Warehouse>> GetWarehouseNoLiquidProductsAsync(List<Warehouse> warehouses)
        {
            return await Task.Run(() => GetWarehouseNoLiquidProducts(warehouses));
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

        public static async Task<Dictionary<Product, double>> AvarageProductAsync(List<Warehouse> warehouses)
        {
            return await Task.Run(() => AvarageProduct(warehouses));
            
        }

    }
}
