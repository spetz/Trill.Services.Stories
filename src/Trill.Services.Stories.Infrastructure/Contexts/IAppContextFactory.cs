using Trill.Services.Stories.Application;

namespace Trill.Services.Stories.Infrastructure.Contexts
{
    internal interface IAppContextFactory
    {
        IAppContext Create();
    }
}