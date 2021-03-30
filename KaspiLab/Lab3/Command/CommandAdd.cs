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


        public delegate void CommandAddDelegate(object sender, WarehouseEventArgs e);
        public event CommandAddDelegate AddCorrectProduct;
        public event CommandAddDelegate AddIncorrectProduct;

        public CommandAdd(Product product, Warehouse warehouse, int count = 1)
        {
            _Product = product;
            _Warehouse = warehouse;
            _Count = count;
        }


        public void Execute()
        {
            if ((_Warehouse is OpenWarehouse) && (_Product is BulkProduct))
            {
                AddIncorrectProduct?.Invoke(this, new WarehouseEventArgs("Открытый склад", "Добавление некорректного товара через комманду", _Product.Name, DateTime.Now));
                throw new Exception("Вы не можете хранить сыпучие продукты на открытых складах!");
            }
            else
            {
                _Warehouse.AddProduct(_Product, _Count);
                AddCorrectProduct?.Invoke(this, new WarehouseEventArgs(_Warehouse.GetType().Name, "Добавление товара через комманду", _Product.Name, DateTime.Now));


            }
            
        }

    }
}
