using System;

namespace hotel.Exceptions
{
    public class GuestIsNullException : Exception
    {
        private const string DefaultMessage = "Guest cannot be null.";
        public override string Message => DefaultMessage;
    }
}