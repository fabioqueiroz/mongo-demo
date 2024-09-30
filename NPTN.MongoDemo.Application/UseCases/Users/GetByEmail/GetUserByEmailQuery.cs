using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.Users.GetByEmail
{
    public sealed class GetUserByEmailQuery : IRequest<UserResponse>
    {
        public string Email { get; init; } = string.Empty;

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }

        internal class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserResponse>
        {
            private readonly IReadOnlyUserRepository _repository;
            public GetUserByEmailQueryHandler(IReadOnlyUserRepository repository)
            {
                _repository = repository;
            }
            public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetUserByEmail(request.Email, cancellationToken);
            }
        }
    }
}
