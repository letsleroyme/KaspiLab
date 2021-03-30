using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class PieceProduct : Product
    {
        private double _cost;
        public override double Cost { get => _cost; set => _cost = value * 0.1; }

        public PieceProduct(string name, string sku, string description, double cost) : base(name, sku, description)
        {
            Cost = cost;
        }

    }
}
