using System.Threading.Tasks;
using Grpc.Core;
using Trill.Services.Ads;

namespace Trill.Services.Stories.Infrastructure.Protos
{
    public class StoryServiceGrpcServer : StoryService.StoryServiceBase
    {
        public override async Task<SendStoryResponse> SendStory(SendStoryCommand request, ServerCallContext context)
        {
            await Task.CompletedTask;
            return new SendStoryResponse();
        }
    }
}