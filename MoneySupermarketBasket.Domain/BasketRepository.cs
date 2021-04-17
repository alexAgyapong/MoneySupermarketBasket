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

            if (IsBreadDiscount(Butter) && IsMilkDiscount(Milk))
            {
                return GetTotalsWithBreadDiscount() + GetTotalsWithMilkDiscount();
            }
            else if (IsBreadDiscount(Butter))
            {
                return GetTotalsWithBreadDiscount(true);
            }
            else if (IsMilkDiscount(Milk))
            {
                return GetTotalsWithMilkDiscount(true);
            }

            return (decimal)basketItems.Sum(x => x.Product.Cost * x.Quantity);
        }

        private decimal GetTotalsWithBreadDiscount(bool includeOtherItems = false)
        {
            var discount = 0.0;
            var itemToDiscount = basketItems.FirstOrDefault(x => x.Product.Name.Equals(Bread));

            if (itemToDiscount != null)
            {
                itemToDiscount.Quantity = itemToDiscount.Quantity > 1 ? itemToDiscount.Quantity - 1 : 0;
                discount = itemToDiscount.Product.Cost * 0.5;
            }

            if (includeOtherItems)
            {
                return (decimal)(basketItems.Sum(x => x.Quantity * x.Product.Cost) + discount);
            }

            return (decimal)(basketItems
                .Where(x => x.Product.Name.Equals(Bread) || x.Product.Name.Equals(Butter))
                .Sum(x => x.Quantity * x.Product.Cost) + discount);
        }

        private decimal GetTotalsWithMilkDiscount(bool includeOtherItems = false)
        {
            var milkItem = basketItems.FirstOrDefault(x => x.Product.Name.Equals(Milk));
            milkItem.Quantity -= (milkItem.Quantity / 4);

            if (includeOtherItems)
            {
                return (decimal)(basketItems.Sum(x => x.Quantity * x.Product.Cost));
            }

            return (decimal)(basketItems
                .Where(x => x.Product.Name.Equals(Milk))
                .Sum(x => x.Quantity * x.Product.Cost));
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