using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Infrastructure.Options
{
    public sealed class MongoDbSettings
    {
        public const string SectionName = "MongoDatabase";
        public string ConnectionString { get; init; } = string.Empty;
        public string MoviesDatabaseName { get; init; } = string.Empty;
        public string MoviesCollectionName { get; init; } = string.Empty;
        public string UsersCollectionName { get; init; } = string.Empty;
    }
}
