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

        [Fact]
        public void Add_two_items_to_basket()
        {
            var p1 = new Product("Milk", 2.50);
            var p2 = new Product("Bread", 2.50);
            var item = new BasketItem(p1, 3);
            var item2 = new BasketItem(p2, 3);
            var basketRepository = new BasketRepository();

            basketRepository.AddItem(item);
            basketRepository.AddItem(item2);

            var actual = basketRepository.GetBasketItems();
            Assert.Equal(2, actual.Count);
        }

        [Fact]
        public void Update_quantity_when_the_same_item_is_added_twice_to_basket()
        {
            var p1 = new Product("Milk", 2.50);
            var p2 = new Product("Milk", 2.50);
            var item = new BasketItem(p1, 3);
            var item2 = new BasketItem(p2, 3);
            var basketRepository = new BasketRepository();

            basketRepository.AddItem(item);
            basketRepository.AddItem(item2);

            var actual = basketRepository.GetBasketItems();
            Assert.Single(actual);
        }

    }
}
