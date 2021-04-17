using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneySupermarketBasket.Domain
{
    public class BasketRepository : IBasketRepository
    {
        private readonly List<BasketItem> basketItems = new();
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
    }
}