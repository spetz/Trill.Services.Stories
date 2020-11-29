namespace Trill.Services.Stories.Core.Exceptions
{
    public class MissingAuthorNameException : DomainException
    {
        public MissingAuthorNameException() : base("Author name is missing.")
        {
        }
    }
}