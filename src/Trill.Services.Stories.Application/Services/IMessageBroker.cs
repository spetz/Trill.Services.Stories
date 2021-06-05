using System.Threading.Tasks;
using Convey.CQRS.Events;

namespace Trill.Services.Stories.Application.Services
{
    public interface IMessageBroker
    {
        Task PublishAsync(params IEvent[] events);
    }
}