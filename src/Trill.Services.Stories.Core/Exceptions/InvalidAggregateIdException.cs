using System;

namespace Trill.Services.Stories.Core.Exceptions
{
    public class InvalidAggregateIdException : DomainException
    {
        public Guid Id { get; }

        public InvalidAggregateIdException(Guid id) : base($"Invalid aggregate id: {id}")
            => Id = id;
    }
}