using System;

namespace Trill.Services.Stories.Application.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}