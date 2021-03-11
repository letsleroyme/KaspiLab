using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Interfaces
{
    interface IWarehouse
    {
        void AddProduct(Product product);
        Product MoveProduct(Product product);
        Product SearchProduct(string sku);
        double Calculate();
        void SetEmployee();

    }
}
