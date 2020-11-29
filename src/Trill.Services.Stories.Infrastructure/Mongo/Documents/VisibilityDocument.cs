using System;
using Trill.Services.Stories.Core.ValueObjects;

namespace Trill.Services.Stories.Infrastructure.Mongo.Documents
{
    public class VisibilityDocument
    {
        public DateTime From { get; }
        public DateTime To { get; }
        public bool Highlighted { get; }

        public VisibilityDocument()
        {
        }

        public VisibilityDocument(Visibility visibility)
        {
            From = visibility.From;
            To = visibility.To;
            Highlighted = visibility.Highlighted;
        }

        public Visibility ToValueObject() => new Visibility(From, To, Highlighted);
    }
}