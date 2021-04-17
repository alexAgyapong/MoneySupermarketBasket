using MoneySupermarketBasket.Domain;
using MoneySupermarketBasket.Domain.Data;
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

        [Fact]
        public void Print_summary_header()
        {
            consoleWriter = new Mock<IConsoleWriter>();
            var summaryPrinter = new SummaryPrinter(consoleWriter.Object);

            summaryPrinter.Print(new List<BasketItem>(), 0);

            consoleWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();
        }

        [Fact]
        public void Print_checkout_summary_with_header_3_items_and_total()
        {
            consoleWriter = new Mock<IConsoleWriter>();
            var summaryPrinter = new SummaryPrinter(consoleWriter.Object);

            summaryPrinter.Print(ProductData.Items(), 9);

            consoleWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();
            consoleWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();
            consoleWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();
            consoleWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();
            consoleWriter.Setup(x => x.WriteLine(It.IsAny<string>())).Verifiable();
        }

    }
}
