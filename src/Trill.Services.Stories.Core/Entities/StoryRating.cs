using Trill.Services.Stories.Core.ValueObjects;

namespace Trill.Services.Stories.Core.Entities
{
    public class StoryRating
    {
        public StoryRatingId Id { get; }
        public Rate Rate { get; }

        public StoryRating(StoryRatingId id,  Rate rate)
        {
            Id = id;
            Rate = rate;
        }
    }
}