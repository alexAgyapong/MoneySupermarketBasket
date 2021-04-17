using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneySupermarketBasket.Domain
{
    public class BasketRepository : IBasketRepository
    {
        private readonly List<BasketItem> basketItems = new();
        private const string Butter = "Butter";
        private const string Bread = "Bread";

        public BasketRepository()
        {
        }

        public void AddItem(BasketItem item)
        {
            var existingItem = basketItems.FirstOrDefault(x => x.Product.Name.Equals(item.Product.Name));

            if (existingItem == null)
                basketItems.Add(item);
            else
                existingItem.Quantity += item.Quantity;
        }

        public List<BasketItem> GetBasketItems() => basketItems;

        public decimal ComputeTotals()
        {
            if (DiscountFor(Butter))
            {
                var discount = 0.0;
                var itemToDiscount = basketItems.FirstOrDefault(x => x.Product.Name.Equals(Bread));

                if (itemToDiscount != null)
                {
                    itemToDiscount.Quantity--;
                    discount = itemToDiscount.Product.Cost * 0.5;
                    return (decimal)(basketItems.Sum(x => x.Product.Cost * x.Quantity) + discount);
                }
            }

            return (decimal)basketItems.Sum(x => x.Product.Cost * x.Quantity);
        }

        private bool DiscountFor(string productName)
        {
            return basketItems.Where(x => x.Product.Name.Equals(productName)).Any(x => x.Quantity == 2);
        }
    }
}