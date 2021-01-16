using System;

namespace Trill.Services.Stories.Application.Services
{
    public interface IStoryRequestStorage
    {
        void SetStoryId(Guid commandId, long storyId);
        long GetStoryId(Guid commandId);
    }
}