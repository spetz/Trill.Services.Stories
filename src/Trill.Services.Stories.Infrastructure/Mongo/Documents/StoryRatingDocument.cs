using System;
using Trill.Services.Stories.Core.Entities;

namespace Trill.Services.Stories.Infrastructure.Mongo.Documents
{
    public class StoryRatingDocument
    {
        public long StoryId { get; set; }
        public Guid UserId { get; set; }
        public int Rate { get; set; }

        public StoryRatingDocument()
        {
        }

        public StoryRatingDocument(StoryRating rating)
        {
            StoryId = rating.Id.StoryId;
            UserId = rating.Id.UserId;
            Rate = rating.Rate;
        }

        public StoryRating ToEntity() => new StoryRating(new StoryRatingId(StoryId, UserId), Rate);
    }
}