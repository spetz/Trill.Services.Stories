namespace Trill.Services.Stories.Core.Exceptions
{
    public class InvalidStoryTitleException : DomainException
    {
        public InvalidStoryTitleException() : base("Invalid story title.")
        {
        }
    }
}