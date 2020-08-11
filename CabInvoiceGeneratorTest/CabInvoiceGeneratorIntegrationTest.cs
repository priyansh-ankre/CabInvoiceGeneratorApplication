using NUnit.Framework;
using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_WhenCalculatedInInvoiceGenerator_ThenShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            var fare = invoiceGenerator.CalculateFare(2, 5);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void GivenDistanceAndTime_WhenCalculatedInInvoiceGenerator_ThenShouldReturnMinimumFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            var fare = invoiceGenerator.CalculateFare(0.1, 1);
            Assert.AreEqual(5, fare);
        }
    }
}