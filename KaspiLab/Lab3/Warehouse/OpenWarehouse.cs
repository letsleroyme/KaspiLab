using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Products;
using Lab3.Interfaces;

namespace Lab3
{
    class OpenWarehouse : Warehouse
    {
        public OpenWarehouse(Adress adress, int square) : base(adress, square)
        {

        }


        /*public override void AddProduct(Product product, int count = 1)
        {
            if (!(product is BulkProduct))
            {
                if (!ProductDict.ContainsKey(product))
                {
                    ProductDict.Add(product, count);
                    //AddCorrectPoduct?.Invoke(this, new WarehouseEventArgs("Открытый склад", "Добавление товара", product.Name, DateTime.Now));

                }
                else
                {
                    ProductDict[product] += count;
                }
                base.AddCorrectPoduct?.Invoke(this, new WarehouseEventArgs("Открытый склад", "Добавление товара", product.Name, DateTime.Now));
            }
            else
            {
                throw new Exception("Вы не можете хранить сыпучие продукты на открытых складах!");
            }

        }*/



    }
}
