using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_API8.Models
{
    public class SchemaUpdate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AttachedFeatureDescription { get; set; }

        public string SchemaContent { get; set; }

        public Database TargetDbId { get; set; }

        public User SchemaCreatedByUserId { get; set; }

        public BsonType AttachedToProjectId { get; set; }

    }
}
