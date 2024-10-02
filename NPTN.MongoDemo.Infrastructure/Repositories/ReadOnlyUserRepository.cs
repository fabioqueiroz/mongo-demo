using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NPTN.MongoDemo.Application.UseCases.Users;
using NPTN.MongoDemo.Application.UseCases.Users.GetByEmail;
using NPTN.MongoDemo.Domain.Users;
using NPTN.MongoDemo.Infrastructure.DatabaseConnection;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class ReadOnlyUserRepository(IOptions<MongoDbSettings> mongoDatabaseSettings, IMongoConnection mongoConnection) 
        : BaseRepository(mongoDatabaseSettings, mongoConnection), IReadOnlyUserRepository
    {
        public async Task<UserResponse> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            //var projection = new FindExpressionProjectionDefinition<User, UserResponse>(user =>
            //    new UserResponse(user.Id, user.Name, user.Email));

            //return await UsersCollection
            //    .Find(x => x.Email.Equals(email))
            //    .Project(projection)
            //    .FirstOrDefaultAsync(cancellationToken);

            return await UsersCollection
                .AsQueryable()
                .Where(x => x.Email.Equals(email))
                .Select(user => new UserResponse(
                    user.Id, 
                    user.Name, 
                    user.Email))
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
