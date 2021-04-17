using System;

namespace MoneySupermarketBasket.Domain
{
    public class Basket
    {
        private IBasketRepository basketRepository;

        public Basket()
        {
        }

        public Basket(IBasketRepository basketRepository)
        {
            this.basketRepository = basketRepository;
        }

        public void AddItem(BasketItem item)
        {
            basketRepository.AddItem(item);
        }
    }
}