using System;

namespace hotel.Exceptions
{
    public class SuiteCapacityLowerThanGuestsException : Exception
    {
        private const string DefaultMessage = "Suite capacity is lower than the number of guests.";
        public override string Message => DefaultMessage;
    }
}