using System;
using System.Collections.Generic;

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
            basketItems.Add(item);
        }

        public List<BasketItem> GetBasketItems() => basketItems;
    }
}