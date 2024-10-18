using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Domain.MaterialisedViews
{
    public class MovieCommentsMaterialisedView
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; init; } = string.Empty;

        [BsonElement("plot")]
        public string Plot { get; init; } = string.Empty;

        [BsonElement("genres")]
        public List<string> Genres { get; init; } = [];

        [BsonElement("runtime")]
        [BsonRepresentation(BsonType.Int32)]
        public int Runtime { get; init; }

        [BsonElement("name")]
        public string Name { get; init; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; init; } = string.Empty;

        [BsonElement("text")]
        public string Text { get; init; } = string.Empty;
    }
}
