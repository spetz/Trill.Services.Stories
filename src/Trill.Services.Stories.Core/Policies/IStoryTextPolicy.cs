using Trill.Services.Stories.Core.ValueObjects;

namespace Trill.Services.Stories.Core.Policies
{
    public interface IStoryTextPolicy
    {
        void Verify(StoryText storyText);
    }
}