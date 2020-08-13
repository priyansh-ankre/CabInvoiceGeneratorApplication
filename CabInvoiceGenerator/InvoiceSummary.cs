namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public InvoiceSummary(int noOfRides, double totalRidesFare)
        {
            this.noOfRides = noOfRides;
            this.totalRidesFare = totalRidesFare;
            this.avgerageFarePerRide = totalRidesFare / noOfRides;
        }
        public int noOfRides { get; }
        public double totalRidesFare { get; }
        public double avgerageFarePerRide { get;}

    }
}
