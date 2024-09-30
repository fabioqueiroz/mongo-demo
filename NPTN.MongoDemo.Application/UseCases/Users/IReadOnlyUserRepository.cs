using NPTN.MongoDemo.Application.UseCases.Users.GetByEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.Users
{
    public interface IReadOnlyUserRepository
    {
        Task<UserResponse> GetUserByEmail(string email, CancellationToken cancellationToken = default);
    }
}
