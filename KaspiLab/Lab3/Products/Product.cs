﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class Product
    {
        public string Name { get; protected set; }
        public string SKU { get; protected set; }
        public string Description { get; protected set; }

        

        public abstract double Cost { get; set; }

        public Product(string name, string sku, string description)
        {
            Name = name; SKU = sku; Description = description; 
        }

        public override string ToString()
        {
            return $"Название продукта: {Name}, код: {SKU}, описание: {Description}, стоимость: {Cost}";
        }
    }

 





}
