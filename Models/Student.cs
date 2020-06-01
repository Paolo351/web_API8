using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_API8.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [BsonElement("School")]
        public string Department { get; set; }
    }
}
