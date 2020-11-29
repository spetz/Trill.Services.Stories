namespace Trill.Services.Stories.Core.Exceptions
{
    public class InvalidRateException : DomainException
    {
        public int Rate { get; }

        public InvalidRateException(int rate) : base($"Invalid rate: {rate}")
        {
            Rate = rate;
        }
    }
}