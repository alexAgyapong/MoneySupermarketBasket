using System.Collections.Generic;

namespace MoneySupermarketBasket.Domain
{
    public class SummaryPrinter : ISummaryPrinter
    {
        private readonly IConsoleWriter consoleWriter;
        private readonly string SummaryHeader = $"\t\t{"Item",-10}   {"Quantity",-10}  {"SubTotal",-10}\n";

        public SummaryPrinter(IConsoleWriter consoleWriter)
        {
            this.consoleWriter = consoleWriter;
        }

        public void Print(List<BasketItem> items, decimal total)
        {
            consoleWriter.WriteLine(SummaryHeader);
            PrintFormattedItems(FormatItems(items));
            string formattedTotal = $"\t\t{"Total:",-10} £{total,-10:F}";
            consoleWriter.WriteLine("");
            consoleWriter.WriteLine(formattedTotal);
        }
        private void PrintFormattedItems(List<string> items)
        {
            foreach (var item in items) { consoleWriter.WriteLine(item); }
        }

        private static List<string> FormatItems(List<BasketItem> items)
        {
            var result = new List<string>();
            foreach (var item in items)
            {
                var subTotal = item.Quantity * item.Product.Cost;
                var line = $"\t\t{item.Product.Name,-10}  {item.Quantity,-10}  £{subTotal,-10:F}";
                result.Add(line);
            }

            return result;
        }
    }
}