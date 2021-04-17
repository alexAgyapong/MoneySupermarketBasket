﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySupermarketBasket.Domain.Data
{
    public class ProductData
    {
        public static IEnumerable<Product> AvailableProducts => new List<Product>
        {
            new Product{Name = "Butter", Cost = 0.80},
            new Product{Name = "Milk", Cost = 1.15},
            new Product{Name = "Bread", Cost = 1.00},
        };

        public static Product Bread => AvailableProducts.FirstOrDefault(x => x.Name.Equals("Bread"));
        public static Product Milk => AvailableProducts.FirstOrDefault(x => x.Name.Equals("Milk"));
        public static Product Butter => AvailableProducts.FirstOrDefault(x => x.Name.Equals("Butter"));

    }
}
