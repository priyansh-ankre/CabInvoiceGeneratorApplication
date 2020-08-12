using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = new Dictionary<string, List<Ride>>();

        public void AddUserIDRides(string userId,Ride[] rides)
        {
            if (userId == null)
            {
                throw new InvoiceGeneratorException("UserId should not be null", InvoiceGeneratorException.ExceptionType.NULL_USER_EXCEPTION);
            }
            List<Ride> rideList = new List<Ride>();
            rideList.AddRange(rides);
            userRides.Add(userId, rideList);
        }

        public Ride[] GetRides(string userId)
        {
            return userRides[userId].ToArray();
        }
    }
}
