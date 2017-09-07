﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDataMigration.CosmosDataMigrationToolClient
{
    public interface IDataSink
    {
        string SinkName { get; }

        DataSinkArgumentCollection GetSinkArguments(DataSinkRole role, string databaseName, string collectionName);
    }
}
