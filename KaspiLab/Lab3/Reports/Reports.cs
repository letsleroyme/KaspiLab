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
        public static Dictionary<Product, int> ProductsLessThan3(Warehouse warehouse)
        {
            return warehouse.ProductDict.Where(x => x.Value < 3).OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<Product, int> UniqueProducts(Warehouse warehouse)
        {
            return warehouse.ProductDict.Distinct().ToDictionary(x => x.Key, x => x.Value);
        }

        public static Dictionary<Product, int> Top3ProductCount(Warehouse warehouse)
        {
            return warehouse.ProductDict.OrderByDescending(x => x.Value).Take(3).ToDictionary(x => x.Key, x => x.Value);
        }

        public static List<Warehouse> GetWarehouseNoBulkProducts(List<Warehouse> warehouses)
        {
            return warehouses.Select(x => x).OfType<ClosedWarehouse>().Cast<Warehouse>().ToList();
            
        }

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

        public static Dictionary<Product, double> AvarageProduct(List<Warehouse> warehouses)
        {
            /*Dictionary<Product, double> res = new Dictionary<Product, double>();
            //var res = warehouses.Select(x => x.ProductDict.SelectMany(y=>y).Gr)
            foreach (var ware in warehouses)
            {
               res = ware.ProductDict
                    .Select(x => x)
                    .GroupBy(y => y.Key)
                    .ToDictionary(g => g.Key, g => g.Average(y => y.Value));
            }*/
            return warehouses
                .SelectMany(x => x.ProductDict)
                .GroupBy(k => k.Key)
                .ToDictionary(g => g.Key, g => g.Average(k => k.Value));
        }



    }
}
