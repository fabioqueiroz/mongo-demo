using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Infrastructure.Options
{
    public sealed class MongoDbAtlasSettings
    {
        public const string SectionName = "MongoAtlasDatabase";
        public string TransactionRecordDatabaseName { get; init; } = string.Empty;
        public string AtlasConnectionString { get; init; } = string.Empty;
        public string AtlasTestMaterialisedViewName { get; init; } = string.Empty;
    }
}
