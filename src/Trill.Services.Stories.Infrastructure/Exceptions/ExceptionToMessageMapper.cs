using System;
using Convey.MessageBrokers.RabbitMQ;

namespace Trill.Services.Stories.Infrastructure.Exceptions
{
    internal sealed class ExceptionToMessageMapper : IExceptionToMessageMapper
    {
        public object Map(Exception exception, object message) => null;
    }
}

