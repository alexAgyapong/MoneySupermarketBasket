namespace MoneySupermarketBasket.Domain
{
    public class Product
    {

        public string Name { get; set; }
        public double Cost { get; set; }
        public Product(string name, double cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}