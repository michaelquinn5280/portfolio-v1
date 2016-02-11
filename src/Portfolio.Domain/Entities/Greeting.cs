using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Domain.Entities
{
    public class Greeting
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid ProfileId { get; set; }
        public string GreetingTitle { get; set; }
        public string GreetingMessage { get; set; }
        public string SiteInfo { get; set; }
    }
}
