using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract class Product
    {
        [ProductAttribute("Название продукта")]
        public string Name { get; protected set; }
        [ProductAttribute("Код SKU")]
        public string SKU { get; protected set; }
        [ProductAttribute("Описание продукта")]
        public string Description { get; protected set; }
        [ProductAttribute("Стоимость продукта")]
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
