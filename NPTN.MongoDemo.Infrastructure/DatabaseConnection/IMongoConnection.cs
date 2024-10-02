using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPTN.MongoDemo.Infrastructure.DatabaseConnection
{
    internal interface IMongoConnection
    {
        MongoClient ConnectionClient { get; }
        IMongoDatabase DatabaseInstance { get; }
    }
}
