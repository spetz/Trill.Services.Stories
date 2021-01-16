namespace Trill.Services.Stories.Core.Entities
{
    public abstract class AggregateRoot<T> where T : AggregateId<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }

        protected AggregateRoot(T id, int version = 0)
        {
            Id = id;
            Version = version;
        }
    }
}