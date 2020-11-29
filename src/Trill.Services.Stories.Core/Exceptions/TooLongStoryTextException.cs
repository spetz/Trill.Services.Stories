namespace Trill.Services.Stories.Core.Exceptions
{
    public class TooLongStoryTextException : DomainException
    {
        public TooLongStoryTextException( string text) : base($"Too long story text: '{text}'.")
        {
        }
    }
}