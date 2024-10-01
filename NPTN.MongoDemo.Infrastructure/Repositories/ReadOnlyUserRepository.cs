using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDemo.Application.UseCases.Users;
using NPTN.MongoDemo.Application.UseCases.Users.GetByEmail;
using NPTN.MongoDemo.Domain.Users;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class ReadOnlyUserRepository(IOptions<MongoDbSettings> mongoDatabaseSettings) : BaseRepository(mongoDatabaseSettings), IReadOnlyUserRepository
    {
        public async Task<UserResponse> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            //var filter = Builders<User>.Filter.Eq("email", email);
            //var document = await UsersCollection.Find(filter).FirstAsync(cancellationToken);

            var projection = new FindExpressionProjectionDefinition<User, UserResponse>(user => 
                new UserResponse(user.Id, user.Name, user.Email));

            return await UsersCollection
                .Find(x => x.Email.Equals(email))
                .Project(projection)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
