using System;
using Convey.CQRS.Queries;
using Trill.Services.Stories.Application.DTO;

namespace Trill.Services.Stories.Application.Queries
{
    public class GetStory : IQuery<StoryDetailsDto>
    {
        public long StoryId { get; set; }
        public Guid? UserId { get; set; }
    }
}