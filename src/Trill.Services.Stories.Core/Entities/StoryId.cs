namespace Trill.Services.Stories.Core.Entities
{
    public class StoryId : AggregateId<long>
    {
        public StoryId(long value) : base(value)
        {
        }

        public static implicit operator long(StoryId id) => id.Value;

        public static implicit operator StoryId(long id) => new StoryId(id);
    }
}