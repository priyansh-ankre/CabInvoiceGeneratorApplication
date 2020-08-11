using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int noOfRides { get; set; }
        public double totalRidesFare { get; set; }
        public double avgerageFarePerRide { get; set; }

        public void AverageFarePerRideCalculate()
        {
            avgerageFarePerRide = totalRidesFare / noOfRides;
        }
    }
}
