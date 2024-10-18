using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NPTN.MongoDemo.Application.UseCases.Movies;
using NPTN.MongoDemo.Domain.Comments;
using NPTN.MongoDemo.Domain.MaterialisedViews;
using NPTN.MongoDemo.Infrastructure.DatabaseConnection;
using NPTN.MongoDemo.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class MovieCommentsMaterialisedViewRepository(IOptions<MongoDbSettings> mongoDatabaseSettings, IMongoConnection mongoConnection)
        : BaseRepository(mongoDatabaseSettings, mongoConnection), IMovieCommentsMaterialisedViewRepository
    {
        public async Task<IReadOnlyCollection<MovieCommentsMaterialisedView>> CreateMovieCommentsMaterialisedView(CancellationToken cancellationToken = default)
        {
            // using fluent API
            var pipeline = CommentsCollection
                .Aggregate()
                .Lookup(
                    foreignCollection: MoviesCollection,
                    localField: c => c.MovieId,
                    foreignField: m => m.Id,
                    @as: (Comment c) => c.MovieDetails
                )
                .Unwind("movieDetails")
                .Project<BsonDocument>(new BsonDocument
                {
                    { "_id", "$_id" }, 
                    { "plot", "$movieDetails.plot" },   
                    { "genres", "$movieDetails.genres" },
                    { "runtime", "$movieDetails.runtime" },
                    { "name", "$name" },
                    { "email", "$email" },      
                    { "text", "$text" }            
                })
                .Limit(10);

            // Convert the result to a list of MovieCommentsMaterialisedView objects
            var result = await pipeline.ToListAsync(cancellationToken);
            var matViewResult = result.Select(doc => new MovieCommentsMaterialisedView
            {
                Id = doc["_id"].AsObjectId.ToString(),
                Plot = doc["plot"].AsString,
                Genres = doc["genres"].AsBsonArray.Select(g => g.AsString).ToList(),
                Runtime = doc["runtime"].ToInt32(),
                Name = doc["name"].AsString,
                Email = doc["email"].AsString,
                Text = doc["text"].AsString
            }).ToList();

            // using LINQ
            //var matViewResult = await CommentsCollection
            //    .AsQueryable()
            //    .Take(10)
            //    .Join(MoviesCollection, comment => comment.MovieId, movie => movie.Id, (x, y) => new
            //    {
            //        Comment = x,
            //        Movie = y,
            //    })
            //    .Select(x => new MovieCommentsMaterialisedView
            //    {
            //        Id = x.Movie.Id,
            //        Genres = x.Movie.Genres,
            //        Runtime = x.Movie.Runtime,
            //        Plot = x.Movie.Plot,
            //        Email = x.Comment.Email,
            //        Name = x.Comment.Name,
            //        Text = x.Comment.Text
            //    })
            //    .ToListAsync(cancellationToken);

            //await DatabaseInstance.DropCollectionAsync(mongoDatabaseSettings.Value.MovieCommentsMaterialisedViewName);
            //await MovieCommentsMaterialisedViewCollection.InsertManyAsync(matViewResult, null, cancellationToken);

            return matViewResult;
        }
    }
}
