using System;
using System.Threading.Tasks;
using Trill.Services.Stories.Application.Clients.DTO;

namespace Trill.Services.Stories.Application.Clients
{
    public interface IUsersApiClient
    {
        Task<UserDto> GetAsync(Guid userId);
    }
}