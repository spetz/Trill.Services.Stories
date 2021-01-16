namespace Trill.Services.Stories.Core.Exceptions
{
    public class MissingStoryTagsException : DomainException
    {
        public MissingStoryTagsException() : base("Story tags are missing.")
        {
        }
    }
}