namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private double totalRidesFare=0;
        private int noOfRides = 0;
        
        public double CalculateFare(CabRide rideType, double distanceInKm, int timeInMinutes)
        {
            Ride ride = new Ride(rideType, distanceInKm, timeInMinutes);
            return rideType.CalculateCostOfCabRide(ride);
        }

        public InvoiceSummary CalculateRidesFare(Ride[] rides)
        {
            foreach (var ride in rides)
            {
                totalRidesFare += CalculateFare(ride.rideType,ride.distanceInKm, ride.timeInMinutes);
                noOfRides++;
            }

            InvoiceSummary invoiceSummary = new InvoiceSummary(noOfRides,totalRidesFare);
            return invoiceSummary;
        }

    }
}
