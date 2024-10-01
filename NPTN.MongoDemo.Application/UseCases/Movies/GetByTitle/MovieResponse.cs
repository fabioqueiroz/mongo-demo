using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NPTN.MongoDemo.Application.UseCases.Movies.GetByTitle
{
    public class MovieResponse
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; init; }

        [BsonElement("title")]
        public string Title { get; init; } = string.Empty;

        [BsonElement("plot")]
        public string Plot { get; init; } = string.Empty;

        [BsonElement("year")]
        public int Year { get; init; }
    }
}
