using System;
using NLog;

namespace Lab3
{
    class OpenWarehouse : Warehouse
    {
        private Logger log = LogManager.GetCurrentClassLogger();


        public OpenWarehouse(Adress adress, int square) : base(adress, square)
        {

        }

        public override void AddProduct(Product product, int count = 1)
        {
            if ((product is BulkProduct) && (this is OpenWarehouse))
            {
                log.Error("Вы не можете хранить сыпучие продукты на открытых складах!");
                OnAddIncorrect(new WarehouseEventArgs("Открытый склад", "Добавление некорректного товара", product.Name, DateTime.Now));
                throw new Exception("Вы не можете хранить сыпучие продукты на открытых складах!");
            }
            else
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
                log.Debug("Добавление корректного товара");
            }
        }
    }
}
