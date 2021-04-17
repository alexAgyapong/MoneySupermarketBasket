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
        private const string Milk = "Milk";

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
            if (IsBreadDiscount(Butter))
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
            else if (IsMilkDiscount(Milk))
            {
                var milkItem = basketItems.FirstOrDefault(x => x.Product.Name.Equals(Milk));
                milkItem.Quantity -= (milkItem.Quantity / 4);

                return (decimal)(basketItems.Where(x => x.Product.Name.Equals(Milk)).Sum(x => x.Quantity * x.Product.Cost));
            }

            return (decimal)basketItems.Sum(x => x.Product.Cost * x.Quantity);
        }

        private bool IsBreadDiscount(string productName)
        {
            return basketItems.Where(x => x.Product.Name.Equals(productName)).Any(x => x.Quantity == 2);
        }

        private bool IsMilkDiscount(string productName)
        {
            var milkItem = basketItems.FirstOrDefault(x => x.Product.Name.Equals(productName));
            if (milkItem == null)
                return false;

            return IsMultipleOfFour(milkItem.Quantity);
        }

        public static bool IsMultipleOfFour(int value) => value % 4 == 0;

    }
}