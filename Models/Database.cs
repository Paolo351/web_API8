using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_API8.Models
{
    public class Database
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId DatabaseId { get; set; }
        public string Name { get; set; }

        public string Engine { get; set; }
    }
}
