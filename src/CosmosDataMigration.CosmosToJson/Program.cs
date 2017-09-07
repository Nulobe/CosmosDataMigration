using CosmosDataMigration.CosmosDataMigrationToolClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDataMigration.CosmosToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            new CosmosDataMigrationToolClient.CosmosDataMigrationToolClient().Transfer(
                new CosmosSink(new CosmosSinkOptions()
                {
                    ServiceEndpoint = new Uri("https://localhost:8081"),
                    AuthorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="
                }),
                new JsonFileDataSink(new JsonFileDataSinkOptions()
                {
                    OutputDirectory = "C:/CosmosDataMigrationTemp"
                }),
                "Nulobe",
                "Facts");
        }
    }
}
