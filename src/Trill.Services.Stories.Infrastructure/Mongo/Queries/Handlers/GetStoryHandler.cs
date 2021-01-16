using System;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Trill.Services.Stories.Application.DTO;
using Trill.Services.Stories.Application.Queries;
using Trill.Services.Stories.Infrastructure.Mongo.Documents;

namespace Trill.Services.Stories.Infrastructure.Mongo.Queries.Handlers
{
    public class GetStoryHandler : IQueryHandler<GetStory, StoryDetailsDto>
    {
        private readonly IMongoDatabase _database;

        public GetStoryHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<StoryDetailsDto> HandleAsync(GetStory query)
        {
            var story = await _database.GetCollection<StoryDocument>("stories")
                .AsQueryable()
                .SingleOrDefaultAsync(x => x.Id == query.StoryId);

            if (story is null)
            {
                return null;
            }

            var now = DateTime.UtcNow.ToUnixTimeMilliseconds();
            if (story.From > now || story.To < now)
            {
                return null;
            }

            var rates = await _database.GetCollection<StoryRatingDocument>("ratings")
                .AsQueryable()
                .Where(x => x.StoryId == query.StoryId)
                .ToListAsync();

            return story.ToDetailsDto(rates, query.UserId);
        }
        
    }
}