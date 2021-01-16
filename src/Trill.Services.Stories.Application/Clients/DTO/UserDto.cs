using System;

namespace Trill.Services.Stories.Application.Clients.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}