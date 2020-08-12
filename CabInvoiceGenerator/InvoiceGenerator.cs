﻿using System.Collections.Generic;
using System.Linq;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        private readonly int COST_PER_KM = 10;
        private readonly int COST_PER_MINUTE = 1;
        private readonly int MINIMUM_FARE = 5;
        private double totalRidesFare=0;
        private int noOfRides = 0;

        public double CalculateFare(double distanceInKm, int timeInMinutes)
        {
            double totalFare = distanceInKm * COST_PER_KM + timeInMinutes * COST_PER_MINUTE;
            if(totalFare < MINIMUM_FARE)
            {
                return MINIMUM_FARE;
            }
            return totalFare;
        }

        public double CalculateRidesFare(Ride[] rides)
        {

            foreach(var ride in rides)
            {
                totalRidesFare +=CalculateFare(ride.distanceInKm,ride.timeInMinutes);
            }
            return totalRidesFare;
        }

        public InvoiceSummary CalculateRidesFareSummary(Ride[] rides)
        {
            foreach (var ride in rides)
            {
                totalRidesFare += CalculateFare(ride.distanceInKm, ride.timeInMinutes);
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
