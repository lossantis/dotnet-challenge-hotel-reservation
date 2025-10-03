using System;

namespace hotel.Exceptions
{
    public class ExceedSuiteCapacityException : Exception
    {
        private const string DefaultMessage = "The number of guests exceeds the suite capacity.";
        public override string Message => DefaultMessage;
    }
}