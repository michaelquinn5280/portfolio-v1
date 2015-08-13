using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Portfolio.Domain.Entities
{
    public class ContactAttempt
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid ProfileId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
