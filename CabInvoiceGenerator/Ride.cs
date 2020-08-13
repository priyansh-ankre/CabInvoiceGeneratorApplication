namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double distanceInKm;
        public int timeInMinutes;
        public CabRide rideType;

        public Ride( CabRide rideType,double distanceInKm, int timeInMinutes)
        {
            this.distanceInKm = distanceInKm;
            this.timeInMinutes = timeInMinutes;
            this.rideType = rideType;
        }
    }
}
