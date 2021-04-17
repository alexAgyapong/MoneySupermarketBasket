using System.Collections.Generic;

namespace MoneySupermarketBasket.Domain
{
    public class SummaryPrinter : ISummaryPrinter
    {
        private IConsoleWriter consoleWriter;
        private readonly string SummaryHeader = "Item   Quantity  SubTotal";

        public SummaryPrinter(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }

        public void Print(List<BasketItem> items, decimal total)
        {
            consoleWriter.WriteLine(SummaryHeader);
        }
    }
}