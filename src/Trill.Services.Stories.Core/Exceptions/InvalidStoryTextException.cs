namespace Trill.Services.Stories.Core.Exceptions
{
    public class InvalidStoryTextException : DomainException
    {
        public InvalidStoryTextException() : base("Invalid story text.")
        {
        }
    }
}