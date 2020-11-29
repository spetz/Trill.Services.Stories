using System;

namespace Trill.Services.Stories.Application.Exceptions
{
    public class UserNotFoundException : AppException
    {
        public UserNotFoundException(Guid userId) : base($"User with ID: '{userId}' was not found.")
        {
        }
    }
}