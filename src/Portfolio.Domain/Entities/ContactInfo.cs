using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Portfolio.Domain.Entities
{
    public class ContactInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid ProfileId { get; set; }
        public string ContactMessage { get; set; }
        public string ContactInstructions { get; set; }
        public string EmailAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
