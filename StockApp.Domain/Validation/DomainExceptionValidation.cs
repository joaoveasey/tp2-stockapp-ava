using System;

namespace StockApp.Domain.Validation
{
    public static class DomainExceptionValidation
    {
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainException(error);
        }
    }

    public class DomainException : Exception
    {
        public DomainException(string error) : base(error)
        {
        }
    }
}
