using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

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
            var dict = GetAttrs();
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string filename = path + DateTime.Now.ToString().Replace(':', '-') + ".csv";


            using (StreamWriter writer = new StreamWriter(filename, false))
            {

                writer.WriteLine($"{dict["Name"]}; {dict["SKU"]}; {dict["Description"]}; {dict["Cost"]};");
                foreach(var product in products.Products.Keys)
                    writer.WriteLine($"{product.Name}; {product.SKU}; {product.Description}; {product.Cost}");
                }
            }


        


        private static Dictionary<string, string> GetAttrs()
        {

            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = typeof(Product).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    ProductAttribute prAttr = attr as ProductAttribute;
                    if (prAttr != null)
                    {
                        string propName = prop.Name;
                        string auth = prAttr.ColumnName;

                        _dict.Add(propName, auth);
                    }
                }
            }

            return _dict;

        }


    }
}
