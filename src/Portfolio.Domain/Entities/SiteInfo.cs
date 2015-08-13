using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Portfolio.Domain.Entities
{
    public class SiteInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Guid ProfileId { get; set; }
        public string Theme { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
