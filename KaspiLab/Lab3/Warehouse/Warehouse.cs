using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Warehouse
{
    abstract class Warehouse
    {
        public string Adress;
        public int Square;

        public Employee Manager;
        public Product[] Products;

        /*public Warehouse(string adress, int square)
        {
            Adress = adress;
            Square = square;
        }*/


    }
}
