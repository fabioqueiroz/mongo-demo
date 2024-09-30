using Microsoft.Extensions.Options;
using NPTN.MongoDemo.Application.UseCases.Users;
using NPTN.MongoDemo.Domain.Users;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class UserRepository(IOptions<MongoDbSettings> mongoDatabaseSettings) : BaseRepository(mongoDatabaseSettings), IUserRepository
    {
        public async Task<string> CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            var collection = MongoDatabase.GetCollection<User>(UsersCollection);
            await collection.InsertOneAsync(user, null, cancellationToken);

            return user.Id;
        }
    }
}
