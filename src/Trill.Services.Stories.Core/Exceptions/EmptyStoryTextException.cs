namespace Trill.Services.Stories.Core.Exceptions
{
    public class EmptyStoryTextException : DomainException
    {
        public EmptyStoryTextException() : base("Empty story text.")
        {
        }
    }
}