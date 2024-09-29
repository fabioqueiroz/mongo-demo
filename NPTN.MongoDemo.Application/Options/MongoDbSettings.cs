using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Application.Options
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; init; } = string.Empty;

        public string MoviesDatabaseName { get; init; } = string.Empty;

        public string MoviesCollectionName { get; init; } = string.Empty;
    }
}
