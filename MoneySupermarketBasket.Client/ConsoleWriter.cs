using MoneySupermarketBasket.Domain;
using System;

namespace MoneySupermarketBasket.Client
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}