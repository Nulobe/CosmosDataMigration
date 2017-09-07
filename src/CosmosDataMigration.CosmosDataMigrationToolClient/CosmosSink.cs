using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDataMigration.CosmosDataMigrationToolClient
{
    public class CosmosSink : IDataSink
    {
        private readonly CosmosSinkOptions _options;

        public CosmosSink(CosmosSinkOptions options)
        {
            _options = options;
        }

        public string SinkName => "CosmosDB";

        public DataSinkArgumentCollection GetSinkArguments(DataSinkRole role, string databaseName, string collectionName) =>
            new DataSinkArgumentCollection(new Dictionary<string, string>()
            {
                { "ConnectionString", string.Join(";", new Dictionary<string, string>()
                    {
                        { "AccountEndpoint", _options.ServiceEndpoint.ToString() },
                        { "AccountKey", _options.AuthorizationKey },
                        { "Database", databaseName }
                    }
                    .Select(kvp => $"{kvp.Key}={kvp.Value}")) },
                { "Collection", collectionName }
            });
    }
}
