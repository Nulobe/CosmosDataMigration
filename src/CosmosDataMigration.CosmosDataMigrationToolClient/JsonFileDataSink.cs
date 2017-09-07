using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDataMigration.CosmosDataMigrationToolClient
{
    public class JsonFileDataSink : IDataSink
    {
        private readonly JsonFileDataSinkOptions _options;

        public JsonFileDataSink(JsonFileDataSinkOptions options)
        {
            _options = options;
        }

        public string SinkName => "JsonFile";

        public DataSinkArgumentCollection GetSinkArguments(DataSinkRole role, string databaseName, string collectionName) =>
            new DataSinkArgumentCollection(new Dictionary<string, string>()
            {
                { role == DataSinkRole.Source ? "Files" : "File", Path.Combine(_options.OutputDirectory, $"{databaseName}.{collectionName}.json") }
            });
    }
}
