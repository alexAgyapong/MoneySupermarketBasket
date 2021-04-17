using MoneySupermarketBasket.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MoneySupermarketBasket.Tests
{
    public class SummaryPrinterShould
    {
        private Mock<IConsoleWriter> consoleWriter;
        private readonly string SummaryHeader = "Item   Quantity  SubTotal";

        [Fact]
        public void Print_summary_header()
        {
            consoleWriter = new Mock<IConsoleWriter>();
            var summaryPrinter = new SummaryPrinter(consoleWriter.Object);

            summaryPrinter.Print(new List<BasketItem>(), 0);

            consoleWriter.Verify(x => x.WriteLine(SummaryHeader));
        }
    }
}
