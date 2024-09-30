using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Domain.Users
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; } = string.Empty;

        [BsonElement("name")]
        public string Name { get; init; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; init; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; init; } = string.Empty;
    }
}
