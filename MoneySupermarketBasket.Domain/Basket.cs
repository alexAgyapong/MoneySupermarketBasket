using System;

namespace MoneySupermarketBasket.Domain
{
    public class Basket
    {
        private IBasketRepository basketRepository;
        private readonly ISummaryPrinter summaryPrinter;

        public Basket()
        {
        }

        public Basket(IBasketRepository basketRepository, ISummaryPrinter summaryPrinter)
        {
            this.basketRepository = basketRepository;
            this.summaryPrinter = summaryPrinter;
        }

        public void AddItem(BasketItem item)
        {
            basketRepository.AddItem(item);
        }

        public void PrintSummary()
        {
            summaryPrinter.Print(basketRepository.GetBasketItems(), basketRepository.ComputeTotals());
        }
    }
}