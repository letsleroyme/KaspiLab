using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    static class Csv
    {
        public static void CsvWrite(Warehouse warehouse, string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string filename = path + DateTime.Now.ToString().Replace(':', '-') + ".csv";

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                foreach (var product in warehouse.ProductDict.Keys)
                {
                    writer.WriteLine($"{product.Name}; {product.SKU}; {product.Description}; {product.Cost}");
                }
            }
        }



        public static void WriteAllProducts(string path)
        {
            AllProducts products = AllProducts.GetInstance();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string filename = path + DateTime.Now.ToString().Replace(':', '-') + ".csv";

            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                foreach(var product in products.Products.Keys)
                {
                    writer.WriteLine($"{product.Name}; {product.SKU}; {product.Description}; {product.Cost}");
                }
            }


        }



    }
}
