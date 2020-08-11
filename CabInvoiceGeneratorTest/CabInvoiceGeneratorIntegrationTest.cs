using NUnit.Framework;
using CabInvoiceGenerator;
using System.Collections.Generic;

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

        [Test]
        public void GivenMultipleRides_WhenCalculatedInInvoiceGenerator_ThenShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides ={ new Ride(2,5),new Ride (0.1,1) };
            var fare = invoiceGenerator.CalculateRidesFare(rides);
            Assert.AreEqual(30, fare);
        }

        [Test]
        public void GivenMultipleRides_WhenCalculatedInInvoiceGenerator_ThenShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(2, 5), new Ride(0.1, 1) };
            var invoiceSummary = invoiceGenerator.CalculateRidesFareSummary(rides);
            InvoiceSummary expected = new InvoiceSummary()
            {
                noOfRides = 2,
                totalRidesFare = 30,
                avgerageFarePerRide = 15
            };
            object.Equals(expected,invoiceSummary);

        }
    }
}