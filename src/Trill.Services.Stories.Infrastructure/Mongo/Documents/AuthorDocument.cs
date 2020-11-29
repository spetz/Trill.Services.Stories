using System;
using Trill.Services.Stories.Core.ValueObjects;

namespace Trill.Services.Stories.Infrastructure.Mongo.Documents
{
    public class AuthorDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AuthorDocument()
        {
        }
        
        public AuthorDocument(Author author)
        {
            Id = author.Id;
            Name = author.Name;
        }

        public Author ToValueObject() => new Author(Id, Name);
    }
}