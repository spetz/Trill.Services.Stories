namespace Trill.Services.Stories.Application.DTO
{
    public class StoryDetailsDto : StoryDto
    {
        public string Text { get; set; }
        public int UserRate { get; set; }
    }
}