namespace Trill.Services.Stories.Application.Services
{
    public interface IRequestStorage
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
    }
}