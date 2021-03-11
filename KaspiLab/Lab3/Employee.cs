using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Employee
    {
        public string FIO { get; set; } 

        public string Position { get; set; }

        public Employee(string fio, string position)
        {
            FIO = fio; Position = position;
        }

        public override string ToString()
        {
            return $"{FIO}, {Position}\r\n";
        }

    }
}
