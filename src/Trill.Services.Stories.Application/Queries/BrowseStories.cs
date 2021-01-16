using System;
using Convey.CQRS.Queries;
using Trill.Services.Stories.Application.DTO;

namespace Trill.Services.Stories.Application.Queries
{
    public class BrowseStories : PagedQueryBase, IQuery<PagedDto<StoryDto>>
    {
        public string Query { get; set; }
        public DateTime Now { get; set; } = DateTime.UtcNow;
    }
}