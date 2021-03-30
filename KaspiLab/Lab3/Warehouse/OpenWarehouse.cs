using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Interfaces;

namespace Lab3
{
    class OpenWarehouse : Warehouse
    {
        //private event WarehouseHandler AddCorrectPoduct;
         
        public OpenWarehouse(Adress adress, int square) : base(adress, square)
        {

        }

        public override void AddProduct(Product product, int count = 1)
        {
            if ((product is BulkProduct) && (this is OpenWarehouse))
            {
                
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
            }
        }

        private void OpenWarehouse_AddIncorrectPoduct(object sender, WarehouseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
