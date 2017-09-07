﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDataMigration.CosmosDataMigrationToolClient
{
    public static class ArgumentEncoder
    {
        public static string Encode(string name, string value) => $"/{name}:\"{value}\"";
    }
}
