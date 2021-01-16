using System.Threading.Tasks;
using Trill.Services.Stories.Core.Entities;

namespace Trill.Services.Stories.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(UserId id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}