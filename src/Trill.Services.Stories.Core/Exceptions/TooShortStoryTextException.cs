namespace Trill.Services.Stories.Core.Exceptions
{
    public class TooShortStoryTextException : DomainException
    {
        public TooShortStoryTextException( string text) : base($"Too short story text: '{text}'.")
        {
        }
    }
}