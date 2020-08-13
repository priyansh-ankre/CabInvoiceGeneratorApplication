namespace CabInvoiceGenerator
{
    public class CabRide
    {
        public static readonly CabRide NORMAL = new CabRide(10, 1, 5);
        public static readonly CabRide PREMIUM = new CabRide(15, 2, 20);

        private double costPerKm;
        private double costPerMinute;
        private double minimumFare;

        private CabRide(double costPerKm, double costPerMinute, double minimumFare)
        {
            this.costPerKm = costPerKm;
            this.costPerMinute = costPerMinute;
            this.minimumFare = minimumFare;
        }

        public double CalculateCostOfCabRide(Ride ride)
        {
            double totalFare;
            totalFare = ride.distanceInKm * costPerKm + ride.timeInMinutes * costPerMinute;
            if (totalFare < minimumFare)
            {
                return minimumFare;
            }
            return totalFare;
        }
    }
}
