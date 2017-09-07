using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDataMigration.CosmosDataMigrationToolClient
{
    public class CosmosDataMigrationToolClient
    {
        public void Transfer(IDataSink source, IDataSink target, string databaseName, string collectionName)
        {
            var processStartInfo = new ProcessStartInfo()
            {
                FileName = Path.Combine(Directory.GetCurrentDirectory(), "dt-1.7", "dt.exe"),
                Arguments = string.Join(" ", new string[]
                {
                    ArgumentEncoder.Encode("s", source.SinkName),
                    source.GetSinkArguments(DataSinkRole.Source, databaseName, collectionName).ToString("s"),
                    ArgumentEncoder.Encode("t", target.SinkName),
                    target.GetSinkArguments(DataSinkRole.Target, databaseName, collectionName).ToString("t"),
                }),
                UseShellExecute = false
            };

            using (var process = Process.Start(processStartInfo))
            {
                process.WaitForExit();
            }
        }
    }
}
