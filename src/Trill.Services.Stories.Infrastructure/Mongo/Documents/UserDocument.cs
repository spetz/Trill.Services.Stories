using System;
using Convey.Types;
using Trill.Services.Stories.Core.Entities;

namespace Trill.Services.Stories.Infrastructure.Mongo.Documents
{
    public class UserDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Locked { get; set; }

        public UserDocument()
        {
        }
        
        public UserDocument(User user)
        {
            Id = user.Id;
            Name = user.Name;
            CreatedAt = user.CreatedAt;
            Locked = user.Locked;
        }

        public User ToEntity() => new User(Id, Name, CreatedAt, Locked);
    }
}