using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;

namespace Lab3.Warehouse
{
    class OpenWarehouse : Warehouse 
    {
        public Product[] Products 
        { 
            set
            {
                foreach (var product in Products)
                {
                    if (product is BulkProduct bulkProduct)
                        throw new Exception("На открытом складе не могут храниться сыпучие продукты");
                }
            }

            get
            {
                return Products;
            }
        }
    }
}
