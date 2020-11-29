using System;

namespace Trill.Services.Stories.Core.Exceptions
{
    public class InvalidVisibilityPeriodException : DomainException
    {
        public DateTime From { get; }
        public DateTime To { get; }

        public InvalidVisibilityPeriodException(DateTime from, DateTime to)
            : base($"Invalid visibility period: '{from}' - '{to}'.")
        {
            From = @from;
            To = to;
        }
    }
}