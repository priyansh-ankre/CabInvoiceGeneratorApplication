using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double distanceInKm;
        public int timeInMinutes;
        public string rideType;

        public Ride( string rideType,double distanceInKm, int timeInMinutes)
        {
            this.distanceInKm = distanceInKm;
            this.timeInMinutes = timeInMinutes;
            this.rideType = rideType;
        }
    }
}
