using MoneySupermarketBasket.Domain;
using MoneySupermarketBasket.Domain.Data;
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

        [Fact]
        public void Compute_the_total_cost_of_3_different_items_added_to_basket()
        {
            var item = new BasketItem(ProductData.Bread, 1);
            var item2 = new BasketItem(ProductData.Milk, 1);
            var item3 = new BasketItem(ProductData.Butter, 1);
            var basketRepository = new BasketRepository();

            basketRepository.AddItem(item);
            basketRepository.AddItem(item2);
            basketRepository.AddItem(item3);

            decimal actual = basketRepository.ComputeTotals();
            Assert.Equal(2.95M, actual);

        }

        [Fact]
        public void Apply_50_percent_discount_to_2_bread_when_2_butter_and_bread_are_added()
        {
            var item = new BasketItem(ProductData.Bread, 2);
            var item2 = new BasketItem(ProductData.Butter, 2);
            var basketRepository = new BasketRepository();

            basketRepository.AddItem(item);
            basketRepository.AddItem(item2);

            var actual = basketRepository.ComputeTotals();
            Assert.Equal(3.10M, actual);

        }
        [Fact]
        public void Apply_50_percent_discount_to_1_bread_when_2_butter_and_bread_are_added()
        {
            var item = new BasketItem(ProductData.Bread, 1);
            var item2 = new BasketItem(ProductData.Butter, 2);
            var basketRepository = new BasketRepository();

            basketRepository.AddItem(item);
            basketRepository.AddItem(item2);

            var actual = basketRepository.ComputeTotals();
            Assert.Equal(2.10M, actual);

        }

        [Fact]
        public void Apply_4th_milk_free_offer_when_3_milk_are_added()
        {
            var item = new BasketItem(ProductData.Milk, 4);
            var basketRepository = new BasketRepository();

            basketRepository.AddItem(item);

            var actual = basketRepository.ComputeTotals();
            Assert.Equal(3.45M, actual);

        }
    }
}
