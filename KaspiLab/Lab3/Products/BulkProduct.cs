﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Products
{
    class BulkProduct : Product
    {
        private double _cost;
        public override double Cost { get => _cost; set => _cost = value; }
    }
}