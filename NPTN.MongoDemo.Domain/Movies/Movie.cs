using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NPTN.MongoDbDemo.Api.Endpoints.Movies
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("plot")]
        public string Plot { get; set; }

        [BsonElement("genres")]
        public List<string> Genres { get; set; }

        [BsonElement("runtime")]
        [BsonRepresentation(BsonType.Int32)]
        public int Runtime { get; set; }

        [BsonElement("metacritic")]
        [BsonRepresentation(BsonType.Int32)]
        public int Metacritic { get; set; }

        [BsonElement("rated")]
        public string Rated { get; set; }

        [BsonElement("cast")]
        public List<string> Cast { get; set; }

        [BsonElement("poster")]
        public string Poster { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("fullplot")]
        public string FullPlot { get; set; }

        [BsonElement("languages")]
        public List<string> Languages { get; set; }

        [BsonElement("released")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Released { get; set; }

        [BsonElement("directors")]
        public List<string> Directors { get; set; }

        [BsonElement("writers")]
        public List<string> Writers { get; set; }

        [BsonElement("awards")]
        public Awards Awards { get; set; }

        [BsonElement("lastupdated")]
        public string LastUpdated { get; set; }

        [BsonElement("year")]
        [BsonRepresentation(BsonType.Int32)]
        public int Year { get; set; }

        [BsonElement("imdb")]
        public Imdb Imdb { get; set; }

        [BsonElement("countries")]
        public List<string> Countries { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("num_mflix_comments")]
        [BsonRepresentation(BsonType.Int32)]
        public int NumMflixComments { get; set; }
    }

    public class Awards
    {
        [BsonElement("wins")]
        [BsonRepresentation(BsonType.Int32)]
        public int Wins { get; set; }

        [BsonElement("nominations")]
        [BsonRepresentation(BsonType.Int32)]
        public int Nominations { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }
    }

    public class Imdb
    {
        [BsonElement("rating")]
        [BsonRepresentation(BsonType.Double)]
        public double Rating { get; set; }

        [BsonElement("votes")]
        [BsonRepresentation(BsonType.Int32)]
        public int Votes { get; set; }

        [BsonElement("id")]
        [BsonRepresentation(BsonType.Int32)]
        public int ImdbId { get; set; }
    }
}





