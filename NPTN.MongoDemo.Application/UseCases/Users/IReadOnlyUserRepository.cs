using NPTN.MongoDemo.Application.UseCases.Users.GetByEmail;

namespace NPTN.MongoDemo.Application.UseCases.Users
{
    public interface IReadOnlyUserRepository
    {
        Task<UserResponse> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
