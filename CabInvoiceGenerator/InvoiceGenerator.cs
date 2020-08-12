using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private readonly int COST_PER_KM = 10;
        private readonly int COST_PER_MINUTE = 1;
        private readonly int MINIMUM_FARE = 5;
        private readonly double PREMIUM_COST_PER_KM = 15;
        private readonly int PREMIUM_COST_PER_MINUTE = 2;
        private readonly int PREMIUM_MINIMUM_FARE = 20;
        private double totalRidesFare=0;
        private int noOfRides = 0;

        public double CalculateFare(string rideType,double distanceInKm, int timeInMinutes)
        {
            double totalFare;

            if (rideType == "premium")
            {
                totalFare = distanceInKm * PREMIUM_COST_PER_KM + timeInMinutes * PREMIUM_COST_PER_MINUTE;
                if (totalFare < PREMIUM_MINIMUM_FARE)
                {
                    return PREMIUM_MINIMUM_FARE;
                }
                return totalFare;
            }

            totalFare = distanceInKm * COST_PER_KM + timeInMinutes * COST_PER_MINUTE;
            if (totalFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            return totalFare;

        }

        public InvoiceSummary CalculateRidesFare(Ride[] rides)
        {
            foreach (var ride in rides)
            {
                totalRidesFare += CalculateFare(ride.rideType,ride.distanceInKm, ride.timeInMinutes);
                noOfRides++;
            }

            InvoiceSummary invoiceSummary = new InvoiceSummary();
            invoiceSummary.totalRidesFare = totalRidesFare;
            invoiceSummary.noOfRides = noOfRides;
            invoiceSummary.AverageFarePerRideCalculate();
            return invoiceSummary;
        }

    }
}
