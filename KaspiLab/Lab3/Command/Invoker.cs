using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Invoker
    {
        Queue<ICommand> Commands;
        public Invoker()
        {
            Commands = new Queue<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            Commands.Enqueue(command);
        }


        
        public void AddProduct()
        {
            Commands?.Dequeue()?.Execute();
        }



    }
}
