using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class CommandAdd : ICommand
    {
        private Warehouse _Warehouse;
        private Product _Product;
        private int _Count;

        public CommandAdd(Product product, Warehouse warehouse, int count = 1)
        {
            _Product = product;
            _Warehouse = warehouse;
            _Count = count;
        }


        public void Execute()
        {
            if (!(_Warehouse is OpenWarehouse) && !(_Product is BulkProduct))
            {
                _Warehouse.AddProduct(_Product, _Count);
                _Warehouse.OnAddCorrect(new WarehouseEventArgs(_Warehouse.WarehouseAdress.ToString(), "Добавление товара через комманду", _Product.Name, DateTime.Now));
            }
            else
            {
                _Warehouse.OnAddIncorrect(new WarehouseEventArgs("Открытый склад", "Добавление некорректного товара чеоез комманду", _Product.Name, DateTime.Now));
                throw new Exception("Вы не можете хранить сыпучие продукты на открытых складах!");
            }
            
        }

    }
}
