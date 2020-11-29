using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Convey;
using Convey.CQRS.Events;
using Convey.MessageBrokers;
using Microsoft.Extensions.Logging;
using Trill.Services.Stories.Application.Services;

namespace Trill.Services.Stories.Infrastructure.Services
{
    internal class MessageBroker : IMessageBroker
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ILogger<IMessageBroker> _logger;

        public MessageBroker(IBusPublisher busPublisher, ILogger<IMessageBroker> logger)
        {
            _busPublisher = busPublisher;
            _logger = logger;
        }

        public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

        private async Task PublishAsync(IEnumerable<IEvent> events)
        {
            if (events is null)
            {
                return;
            }

            foreach (var @event in events)
            {
                if (@event is null)
                {
                    continue;
                }

                var messageId = Guid.NewGuid().ToString("N");
                var messageName = @event.GetType().Name.Underscore();
                _logger.LogTrace($"Publishing integration event: {messageName} [ID: '{messageId}'].");
                await _busPublisher.PublishAsync(@event, messageId);
            }
        }
    }
}