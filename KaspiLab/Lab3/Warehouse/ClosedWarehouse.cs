using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;
using Lab3.Interfaces;

namespace Lab3
{
    class ClosedWarehouse : Warehouse
    {
        public ClosedWarehouse(Adress adress, int square) : base(adress, square) 
        {
        }

    }
}
