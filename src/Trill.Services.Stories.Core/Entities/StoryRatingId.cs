namespace Trill.Services.Stories.Core.Entities
{
    public class StoryRatingId
    {
        public StoryId StoryId { get; }
        public UserId UserId { get; }

        public StoryRatingId(StoryId storyId, UserId userId)
        {
            StoryId = storyId;
            UserId = userId;
        }
    }
}