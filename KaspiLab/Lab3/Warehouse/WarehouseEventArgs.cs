using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class WarehouseEventArgs
    {
        public string WarehouseName { get; private set; }
        public string TypeOfEvent { get; private set; }
        public string ProductName { get; private set; }
        public DateTime Time { get; private set; }

        public WarehouseEventArgs(string warename, string eventtype, string productname, DateTime time)
        {
            WarehouseName = warename;
            TypeOfEvent = eventtype;
            ProductName = productname;
            Time = time;
        }

    }
}
