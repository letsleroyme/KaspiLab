using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Interfaces
{
    interface IWarehouse
    {
        void AddProduct(Product product, int count);
        void MoveProduct(Product product, Warehouse warehouse, int count = 1);
        string SearchProductString(string sku);
        double Calculate();
        void SetEmployee(Employee emp);

    }
}
