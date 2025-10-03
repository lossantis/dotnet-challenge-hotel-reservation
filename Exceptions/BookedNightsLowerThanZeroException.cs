using System;

namespace hotel.Exceptions
{
    public class BookedNightsLowerThanZeroException : Exception
    {
        private const string DefaultMessage = "The number of booked nights must be at least 1.";
        public override string Message => DefaultMessage;    
    }
}