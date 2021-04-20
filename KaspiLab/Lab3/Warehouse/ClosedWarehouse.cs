using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Interfaces;
using NLog;

namespace Lab3
{
    class ClosedWarehouse : Warehouse
    {
        private Logger log = LogManager.GetCurrentClassLogger();

        public ClosedWarehouse(Adress adress, int square) : base(adress, square) 
        {
        }

        public override void AddProduct(Product product, int count = 1)
        {
            if (!ProductDict.ContainsKey(product))
            {
                ProductDict.Add(product, count);
            }
            else
            {
                ProductDict[product] += count;
            }
            OnAddCorrect(new WarehouseEventArgs("Открытый склад", "Добавление корректного товара", product.Name, DateTime.Now));
            log.Debug("Добавление корректного товара на открытый склад");
        }

    }
}
