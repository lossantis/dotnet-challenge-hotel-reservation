using System;

namespace hotel.Exceptions
{
    public class SuiteIsNullException : Exception
    {
        private const string DefaultMessage = "Suite cannot be null.";
        public override string Message => DefaultMessage;
    }
}