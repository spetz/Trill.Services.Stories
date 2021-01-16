using System.Linq;
using System.Threading.Tasks;
using Convey.CQRS.Queries;
using Convey.Persistence.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Trill.Services.Stories.Application.DTO;
using Trill.Services.Stories.Application.Queries;
using Trill.Services.Stories.Infrastructure.Mongo.Documents;

namespace Trill.Services.Stories.Infrastructure.Mongo.Queries.Handlers
{
    public class BrowseStoriesHandler : IQueryHandler<BrowseStories, PagedDto<StoryDto>>
    {
        private readonly IMongoDatabase _database;

        public BrowseStoriesHandler(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<PagedDto<StoryDto>> HandleAsync(BrowseStories query)
        {
            var now = query.Now.ToUnixTimeMilliseconds();
            var documents = _database.GetCollection<StoryDocument>("stories")
                .AsQueryable()
                .Where(x => x.From <= now && x.To >= now);

            var input = query.Query;
            if (!string.IsNullOrWhiteSpace(input))
            {
                documents = documents.Where(x =>
                    x.Title.Contains(input) || x.Author.Name.Contains(input) || x.Tags.Contains(input));
            }
            
            var result = await documents.OrderByDescending(x => x.CreatedAt).PaginateAsync(query);
            var storyIds = result.Items.Select(x => x.Id);

            var rates = await _database.GetCollection<StoryRatingDocument>("ratings")
                .AsQueryable()
                .Where(x => storyIds.Contains(x.StoryId))
                .ToListAsync();
            
            var pagedResult = PagedResult<StoryDto>.From(result, result.Items.Select(x => x.ToDto(rates)));
            
            return new PagedDto<StoryDto>
            {
                CurrentPage = pagedResult.CurrentPage,
                TotalPages = pagedResult.TotalPages,
                ResultsPerPage = pagedResult.ResultsPerPage,
                TotalResults = pagedResult.TotalResults,
                Items = pagedResult.Items
            };
        }
    }
}