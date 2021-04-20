using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Lab3
{
    class Invoker
    {

        public delegate void AddCommandToQueue(object sender, CommandQueueEventArgs e);
        public event AddCommandToQueue QueueAdd;
        public event AddCommandToQueue QueueExecute;
        Logger log = LogManager.GetCurrentClassLogger();
        Queue<ICommand> Commands;
        public Invoker()
        {
            Commands = new Queue<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            Commands.Enqueue(command);
            log.Debug("Комманда добавлена");
            QueueAdd?.Invoke(this, new CommandQueueEventArgs("Добавление команды", DateTime.Now));
        }


        
        public void AddProduct()
        {

            Commands?.Dequeue()?.Execute();
            log.Debug("Комманда выполнена");
            QueueExecute?.Invoke(this, new CommandQueueEventArgs("Выполнение команлы", DateTime.Now));
        }

        public bool CheckQueueForNull()
        {
            return Commands.Count == 0 ? false : true;
        }


    }
}
