using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Domain.Entities
{
    public class ProfileReference
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ReferenceValue { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid ProfileId { get; set; }
    }
}
