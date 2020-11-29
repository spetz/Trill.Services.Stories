using System.Threading.Tasks;
using Trill.Services.Stories.Core.Entities;

namespace Trill.Services.Stories.Core.Repositories
{
    public interface IStoryRepository
    {
        Task<Story> GetAsync(StoryId id);
        Task AddAsync(Story story);
    }
}