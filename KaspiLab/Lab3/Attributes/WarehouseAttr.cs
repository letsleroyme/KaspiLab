using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    class WarehouseAttr : Attribute
    {
        public string ColumnName { get; set; }

        public WarehouseAttr() { }

        public WarehouseAttr(string name)
        {
            ColumnName = name;
        }

    }
}
