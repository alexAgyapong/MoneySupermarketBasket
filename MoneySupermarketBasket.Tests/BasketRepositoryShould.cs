using MoneySupermarketBasket.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoneySupermarketBasket.Tests
{
    public class BasketRepositoryShould
    {
        [Fact]
        public void Add_one_item_to_basket()
        {
            var p1 = new Product("Milk", 2.50);
            var item = new BasketItem(p1, 3);
            var basketRepository = new BasketRepository();

            basketRepository.AddItem(item);

            List<BasketItem> actual = basketRepository.GetBasketItems();
            Assert.Single(actual);

        }
    }
}
