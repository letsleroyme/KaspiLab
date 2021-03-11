using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Warehouse;
using Lab3.Products;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Иван Иванович Иванов", "Зав. складом");
            Employee emp2 = new Employee("Петр Петрович Петров", "Управляющий");
            Employee emp3 = new Employee("Александр Александрович Александров", "Старший складской рабочий");

            Lab3.Warehouse.Warehouse[] warehouses = new Lab3.Warehouse.Warehouse[4];

            warehouses[0] = new ClosedWarehouse();
            warehouses[1] = new ClosedWarehouse();
            warehouses[2] = new OpenWarehouse();
            warehouses[3] = new OpenWarehouse();





        }
    }
}
