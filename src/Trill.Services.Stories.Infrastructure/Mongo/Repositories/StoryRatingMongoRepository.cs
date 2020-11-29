using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Trill.Services.Stories.Core.Entities;
using Trill.Services.Stories.Core.Repositories;
using Trill.Services.Stories.Infrastructure.Mongo.Documents;

namespace Trill.Services.Stories.Infrastructure.Mongo.Repositories
{
    public class StoryRatingMongoRepository : IStoryRatingRepository
    {
        private readonly IMongoDatabase _database;

        public StoryRatingMongoRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<int> GetTotalRatingAsync(StoryId storyId)
            => await _database.GetCollection<StoryRatingDocument>("ratings")
                .AsQueryable()
                .Where(x => x.StoryId == storyId)
                .SumAsync(x => x.Rate);

        public Task SetAsync(StoryRating rating)
            => _database.GetCollection<StoryRatingDocument>("ratings")
                .ReplaceOneAsync(x => x.StoryId == rating.Id.StoryId && x.UserId == rating.Id.UserId,
                    new StoryRatingDocument(rating), new ReplaceOptions
                    {
                        IsUpsert = true
                    });
    }
}