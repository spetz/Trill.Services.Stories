using System;

namespace Trill.Services.Stories.Core.Entities
{
    public class UserId : AggregateId<Guid>
    {
        public UserId() : base(Guid.NewGuid())
        {
        }
        
        public UserId(Guid value) : base(value)
        {
        }
        
        public static implicit operator Guid(UserId id) => id.Value;

        public static implicit operator UserId(Guid id) => new UserId(id);
    }
}