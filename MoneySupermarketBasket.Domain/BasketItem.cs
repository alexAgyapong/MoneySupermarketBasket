namespace MoneySupermarketBasket.Domain
{
    public class BasketItem
    {
        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public int Quantity { get; set; }
        public Product Product { get; }
    }
}