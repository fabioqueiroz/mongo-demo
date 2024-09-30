using NPTN.MongoDemo.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.Users
{
    public interface IUserRepository
    {
        Task<string> CreateUserAsync(User user, CancellationToken cancellationToken = default);
        Task<User?> GetUserByIdAsync(string id, CancellationToken cancellationToken = default);
        Task UpdateUserAsync(User user, CancellationToken cancellationToken = default);
        Task DeleteUserByIdAsync(string id, CancellationToken cancellationToken = default);
    }
}
