using MoneySupermarketBasket.Domain;
using MoneySupermarketBasket.Domain.Data;
using Moq;
using System;
using Xunit;

namespace MoneySupermarketBasket.Tests
{
    public class BasketShould
    {
        private Mock<IBasketRepository> basketRepository;
        private Mock<ISummaryPrinter> summaryPrinter;

        [Fact]
        public void Be_Truthy()
        {
            Assert.True(true);
        }
        [Fact]
        public void Save_added_items()
        {
            basketRepository = new Mock<IBasketRepository>();
            summaryPrinter = new Mock<ISummaryPrinter>();
            var basket = new Basket(basketRepository.Object, summaryPrinter.Object);
            var product = new Product("Bread", 1.50);
            var item = new BasketItem(product, 1);

            basket.AddItem(item);

            basketRepository.Verify(x => x.AddItem(item));
        }

        [Fact]
        public void Print_summary_with_totals()
        {
            basketRepository = new Mock<IBasketRepository>();
            summaryPrinter = new Mock<ISummaryPrinter>();
            var basket = new Basket(basketRepository.Object, summaryPrinter.Object);
            var items = ProductData.Items();
            decimal total = 10.0M;
            basketRepository.Setup(x => x.ComputeTotals()).Returns(total);
            basketRepository.Setup(x => x.GetBasketItems()).Returns(items);

            basket.PrintSummary();

            summaryPrinter.Verify(x => x.Print(items, total));
        }

    }
}
