using MoneySupermarketBasket.Domain;
using MoneySupermarketBasket.Domain.Data;
using System;

namespace MoneySupermarketBasket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleWriter = new ConsoleWriter();
            var basketRepository = new BasketRepository();
            var summaryPrinter = new SummaryPrinter(consoleWriter);
            var basket = new Basket(basketRepository, summaryPrinter);

            var item = new BasketItem(ProductData.Butter, 2);
            var item2 = new BasketItem(ProductData.Bread, 1);
            var item3 = new BasketItem(ProductData.Milk, 8);

            basket.AddItem(item);
            basket.AddItem(item2);
            basket.AddItem(item3);

            Console.WriteLine();
            Console.WriteLine("\t\tBasket summary with applied discount(s)");
            Console.WriteLine();
            basket.PrintSummary();


            Console.ReadLine();
        }
    }
}
