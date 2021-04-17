namespace MoneySupermarketBasket.Domain
{
    public class BasketItem
    {
        private Product product;
        private int v;

        public BasketItem(Product product, int v)
        {
            this.product = product;
            this.v = v;
        }
    }
}