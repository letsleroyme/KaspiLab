using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class CommandQueueEventArgs
    {
        public string CommandStatus { get; private set; }
        public DateTime CommandTime { get; private set; }

        public CommandQueueEventArgs(string commandstatus, DateTime commandtime)
        {
            CommandStatus = commandstatus;
            CommandTime = commandtime;
        }


    }
}
