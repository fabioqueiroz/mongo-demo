using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.AtlasTests.MaterialisedView
{
    public sealed class GetAtlasTestMaterialisedViewQuery : IRequest<object>
    {
        internal class GetAtlasTestMaterialisedViewQueryHandler(IAtlasMaterialisedViewRepository repository) : IRequestHandler<GetAtlasTestMaterialisedViewQuery, object>
        {
            private readonly IAtlasMaterialisedViewRepository _repository = repository;

            public async Task<object> Handle(GetAtlasTestMaterialisedViewQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetAtlasTestMaterialisedViewAsync(cancellationToken);
            }
        }
    }
}
