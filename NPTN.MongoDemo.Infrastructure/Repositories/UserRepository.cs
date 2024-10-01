using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDemo.Application.UseCases.Users;
using NPTN.MongoDemo.Domain.Users;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class UserRepository(IOptions<MongoDbSettings> mongoDatabaseSettings) : BaseRepository(mongoDatabaseSettings), IUserRepository
    {
        public async Task<string> CreateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await UsersCollection.InsertOneAsync(user, null, cancellationToken);
            return user.Id;
        }

        public async Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await UsersCollection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await UsersCollection.ReplaceOneAsync(x => x.Id == user.Id, user, cancellationToken: cancellationToken);
        }

        public async Task DeleteUserByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            await UsersCollection.DeleteOneAsync(x => x.Id == id, cancellationToken);
        }
    }
}
