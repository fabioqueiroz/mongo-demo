using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Domain.Comments
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; } = null!;

        [BsonElement("name")]
        public string Name { get; init; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; init; } = string.Empty;

        [BsonElement("movie_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string MovieId { get; init; } = string.Empty;

        [BsonElement("text")]
        public string Text { get; init; } = string.Empty;

        [BsonElement("date")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; init; }

        [BsonElement("movieDetails")]
        public string? MovieDetails { get; init; }
    }
}
