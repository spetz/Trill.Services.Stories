namespace Trill.Services.Stories.Application.Exceptions
{
    public class StoryNotFoundException : AppException
    {
        public StoryNotFoundException(long storyId) : base($"Story with ID: '{storyId}' was not found.")
        {
        }
    }
}