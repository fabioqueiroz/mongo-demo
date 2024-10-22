using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NPTN.MongoDemo.Infrastructure.DatabaseConnection;
using NPTN.MongoDemo.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Infrastructure.Repositories
{
    internal abstract class AtlasBaseRepository
    {
        private readonly IMongoAtlasConnection _mongoAtlasConnection;
        public IMongoDatabase DatabaseInstance => _mongoAtlasConnection.DatabaseInstance;
        protected IMongoCollection<BsonDocument> AtlasTestMaterialisedViewCollection { get; private set; }

        protected AtlasBaseRepository(IOptions<MongoDbAtlasSettings> mongoAtlasDatabaseSettings, IMongoAtlasConnection mongoAtlasConnection)
        {
            _mongoAtlasConnection = mongoAtlasConnection;
            AtlasTestMaterialisedViewCollection = _mongoAtlasConnection.DatabaseInstance.GetCollection<BsonDocument>(mongoAtlasDatabaseSettings.Value.AtlasTestMaterialisedViewName);
        }
    }
}
