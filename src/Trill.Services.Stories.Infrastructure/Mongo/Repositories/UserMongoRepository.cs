using System;
using System.Threading.Tasks;
using Convey.Persistence.MongoDB;
using Trill.Services.Stories.Core.Entities;
using Trill.Services.Stories.Core.Repositories;
using Trill.Services.Stories.Infrastructure.Mongo.Documents;

namespace Trill.Services.Stories.Infrastructure.Mongo.Repositories
{
    public class UserMongoRepository : IUserRepository
    {
        private readonly IMongoRepository<UserDocument, Guid> _repository;

        public UserMongoRepository(IMongoRepository<UserDocument, Guid> repository)
            => _repository = repository;

        public async Task<User> GetAsync(UserId id)
        {
            var document = await _repository.GetAsync(r => r.Id == id);
            return document?.ToEntity();
        }

        public Task AddAsync(User user)
            => _repository.AddAsync(new UserDocument(user));

        public Task UpdateAsync(User user)
            => _repository.UpdateAsync(new UserDocument(user));
    }
}