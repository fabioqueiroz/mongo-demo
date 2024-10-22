using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json.Linq;
using NPTN.MongoDemo.Application.UseCases.AtlasTests.MaterialisedView;
using NPTN.MongoDemo.Infrastructure.DatabaseConnection;
using NPTN.MongoDemo.Infrastructure.Options;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal class AtlasMaterialisedViewRepository(IOptions<MongoDbAtlasSettings> mongoAtlasDatabaseSettings, IMongoAtlasConnection mongoAtlasConnection)
        : AtlasBaseRepository(mongoAtlasDatabaseSettings, mongoAtlasConnection), IAtlasMaterialisedViewRepository
    {
        public async Task<dynamic> GetAtlasTestMaterialisedViewAsync(CancellationToken cancellationToken = default)
        {
            var documents = await AtlasTestMaterialisedViewCollection
                .AsQueryable()
                .Take(10)
                .ToListAsync(cancellationToken);

            var jsonString = documents.ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.CanonicalExtendedJson });
            var result = System.Text.Json.JsonSerializer.Deserialize<dynamic>(jsonString);

            //var jsonObject = JObject.Parse(jsonString); // throwing Newtonsoft.Json exception error

            return result ?? string.Empty;
        }
    }
}
