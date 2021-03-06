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
            var fare = invoiceGenerator.CalculateFare(CabRide.NORMAL,2, 5);
            Assert.AreEqual(25, fare);
        }

        [Test]
        public void GivenDistanceAndTime_WhenCalculatedInInvoiceGenerator_ThenShouldReturnMinimumFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            var fare = invoiceGenerator.CalculateFare(CabRide.NORMAL, 0.1, 1);
            Assert.AreEqual(5, fare);
        }

        [Test]
        public void GivenMultipleRides_WhenCalculatedInInvoiceGenerator_ThenShouldReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides ={ new Ride(CabRide.NORMAL, 2,5),new Ride (CabRide.NORMAL, 0.1,1) };
            var fare = invoiceGenerator.CalculateRidesFare(rides);
            Assert.AreEqual(30, fare.totalRidesFare);
        }

        [Test]
        public void GivenMultipleRides_WhenCalculatedInInvoiceGenerator_ThenShouldReturnInvoiceSummary()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            Ride[] rides = { new Ride(CabRide.NORMAL, 2, 5), new Ride(CabRide.NORMAL, 0.1, 1) };
            var invoiceSummary = invoiceGenerator.CalculateRidesFare(rides);
            Assert.AreEqual(2,invoiceSummary.noOfRides);
            Assert.AreEqual(30, invoiceSummary.totalRidesFare);
            Assert.AreEqual(15, invoiceSummary.avgerageFarePerRide);
        }

        [Test]
        public void GivenUerIDAndListOfRides_WhenCalculated_ThenShouldReturnInvoice()
        {
            string userId = "Priyansh Ankre";
            Ride[] rides = { new Ride(CabRide.NORMAL, 2, 5), new Ride(CabRide.NORMAL, 0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddUserIDRides(userId, rides);
            InvoiceGenerator invoice = new InvoiceGenerator();
            var total = invoice.CalculateRidesFare(rideRepository.GetRides(userId));
            Assert.AreEqual(30, total.totalRidesFare);
        }

        [Test]
        public void GivenUerIDAndListOfRides_WhenCalculated_ThenShouldNullUserException()
        {
            string userId = null;
            Ride[] rides = { new Ride(CabRide.NORMAL, 2, 5), new Ride(CabRide.NORMAL, 0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            InvoiceGeneratorException exception = Assert.Throws<InvoiceGeneratorException>(() => rideRepository.AddUserIDRides(userId, rides));
            Assert.AreEqual(InvoiceGeneratorException.ExceptionType.NULL_USER_EXCEPTION, exception.type);
        }

        [Test]
        public void GivenUerIDAndListOfRides_WhenCalculated_ThenShouldReturnPremiumInvoice()
        {
            string userId1 = "Priyansh";
            string userId2 = "Ankre";
            Ride[] rides1 = { new Ride(CabRide.PREMIUM, 2, 5), new Ride(CabRide.PREMIUM, 0.1, 1) };
            Ride[] rides2 = { new Ride(CabRide.PREMIUM, 2, 5), new Ride(CabRide.PREMIUM, 0.1, 1) };
            RideRepository rideRepository = new RideRepository();
            rideRepository.AddUserIDRides(userId1, rides1);
            rideRepository.AddUserIDRides(userId2, rides2);
            InvoiceGenerator invoice = new InvoiceGenerator();
            var total1 = invoice.CalculateRidesFare(rideRepository.GetRides(userId1));
            var total2 = invoice.CalculateRidesFare(rideRepository.GetRides(userId2));
            Assert.AreEqual(120, total2.totalRidesFare);
        }
    }
}