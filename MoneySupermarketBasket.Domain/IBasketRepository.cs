using System.Collections.Generic;

namespace MoneySupermarketBasket.Domain
{
    public interface IBasketRepository
    {
        void AddItem(BasketItem item);
        decimal ComputeTotals();
        List<BasketItem> GetBasketItems();
    }
}