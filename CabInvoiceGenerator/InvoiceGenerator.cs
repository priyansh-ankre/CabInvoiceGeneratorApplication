namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        public readonly int COST_PER_KM = 10;
        public readonly int COST_PER_MINUTE = 1;
        public readonly int MINIMUM_FARE = 5;

        public double CalculateFare(double distanceInKm,int timeInMinutes)
        {
            double totalFare = distanceInKm * COST_PER_KM + timeInMinutes * COST_PER_MINUTE;
            if(totalFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            return totalFare;
        }
    }
}
