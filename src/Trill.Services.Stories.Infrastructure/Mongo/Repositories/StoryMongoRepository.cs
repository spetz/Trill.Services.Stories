using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Trill.Services.Stories.Core.Entities;
using Trill.Services.Stories.Core.Repositories;
using Trill.Services.Stories.Infrastructure.Mongo.Documents;

namespace Trill.Services.Stories.Infrastructure.Mongo.Repositories
{
    public class StoryMongoRepository : IStoryRepository
    {
        private readonly IMongoRepository<StoryDocument, long> _repository;

        public StoryMongoRepository(IMongoRepository<StoryDocument, long> repository)
            => _repository = repository;

        public async Task<Story> GetAsync(StoryId id)
        {
            var document = await _repository.GetAsync(r => r.Id == id);
            return document?.ToEntity();
        }

        public Task AddAsync(Story story) => _repository.AddAsync(new StoryDocument(story));
    }
}