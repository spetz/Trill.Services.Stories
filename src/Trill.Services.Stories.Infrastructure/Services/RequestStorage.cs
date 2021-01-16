using System;
using Microsoft.Extensions.Caching.Memory;
using Trill.Services.Stories.Application.Services;

namespace Trill.Services.Stories.Infrastructure.Services
{
    internal class RequestStorage : IRequestStorage
    {
        private readonly IMemoryCache _cache;

        public RequestStorage(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Set<T>(string key, T value) => _cache.Set(key, value, TimeSpan.FromSeconds(5));

        public T Get<T>(string key) => _cache.Get<T>(key);
    }
}