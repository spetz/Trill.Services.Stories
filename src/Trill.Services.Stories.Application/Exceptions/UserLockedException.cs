using System;

namespace Trill.Services.Stories.Application.Exceptions
{
    public class UserLockedException : AppException
    {
        public Guid UserId { get; }

        public UserLockedException(Guid userId) : base($"User with ID: '{userId}' is locked.")
        {
            UserId = userId;
        }
    }
}