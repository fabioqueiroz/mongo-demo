using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.Users.GetByEmail
{
    public record UserResponse(string Id, string Name, string Email);
}
