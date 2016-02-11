using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Domain.Entities
{
    public class Profile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Guid ProfileId { get; set; }
        public string ProfileImagePath { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public List<TechnicalApplication> Applications { get; set; }
        public List<Proficiency> Proficiencies { get; set; }
        public string EmployerSummary { get; set; }
        public IEnumerable<Company> Employers { get; set; }
    }
}
