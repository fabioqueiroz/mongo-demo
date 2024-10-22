using Microsoft.Extensions.Options;
using MongoDB.Driver;
using NPTN.MongoDemo.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Infrastructure.DatabaseConnection
{
    internal class MongoAtlasConnection : IMongoAtlasConnection
    {
        public MongoClient ConnectionClient { get; private set; }
        public IMongoDatabase DatabaseInstance { get; private set; }

        public MongoAtlasConnection(IOptions<MongoDbAtlasSettings> mongoAtlasDatabaseSettings)
        {
            //var mongoClientSettings = MongoClientSettings.FromConnectionString(mongoAtlasDatabaseSettings.Value.AtlasConnectionString);
            //mongoClientSettings.Credential = MongoCredential
            //    .CreateOidcCredential("azure", "<db_username>")
            //    .WithMechanismProperty("TOKEN_RESOURCE", "<audience>");

            //ConnectionClient = new MongoClient(mongoClientSettings);

            ConnectionClient = new MongoClient(mongoAtlasDatabaseSettings.Value.AtlasConnectionString);
            DatabaseInstance = ConnectionClient.GetDatabase(mongoAtlasDatabaseSettings.Value.TransactionRecordDatabaseName)
                ?? throw new ArgumentNullException("Unable to retrieve the Atlas database with the give connection string.");
        }
    }
}
