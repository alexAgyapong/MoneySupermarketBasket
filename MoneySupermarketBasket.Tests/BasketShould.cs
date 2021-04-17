using MoneySupermarketBasket.Domain;
using Moq;
using System;
using Xunit;

namespace MoneySupermarketBasket.Tests
{
    public class BasketShould
    {
        private Mock<IBasketRepository> basketRepository;
        [Fact]
        public void Be_Truthy()
        {
            Assert.True(true);
        }
        [Fact]
        public void Save_added_items()
        {
            basketRepository = new Mock<IBasketRepository>();
            var basket = new Basket(basketRepository.Object);
            var product = new Product("Bread", 1.50);
            var item = new BasketItem(product, 1);

            basket.AddItem(item);

            basketRepository.Verify(x => x.AddItem(item));
        }
    }
}
