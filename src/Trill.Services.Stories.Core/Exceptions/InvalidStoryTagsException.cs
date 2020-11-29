namespace Trill.Services.Stories.Core.Exceptions
{
    public class InvalidStoryTagsException : DomainException
    {
        public InvalidStoryTagsException() : base("Story tags are invalid.")
        {
        }
    }
}