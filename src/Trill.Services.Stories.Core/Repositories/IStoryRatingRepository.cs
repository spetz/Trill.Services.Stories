using System.Threading.Tasks;
using Trill.Services.Stories.Core.Entities;

namespace Trill.Services.Stories.Core.Repositories
{
    public interface IStoryRatingRepository
    {
        Task<int> GetTotalRatingAsync(StoryId storyId);
        Task SetAsync(StoryRating rating);
    }
}