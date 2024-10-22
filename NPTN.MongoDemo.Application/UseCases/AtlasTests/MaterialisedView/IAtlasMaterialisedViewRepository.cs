using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.UseCases.AtlasTests.MaterialisedView
{
    public interface IAtlasMaterialisedViewRepository
    {
        Task<dynamic> GetAtlasTestMaterialisedViewAsync(CancellationToken cancellationToken = default);
    }
}
