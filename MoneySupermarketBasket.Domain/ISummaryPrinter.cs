using System.Collections.Generic;

namespace MoneySupermarketBasket.Domain
{
    public interface ISummaryPrinter
    {
        void Print(List<BasketItem> items, decimal total);
    }
}