using Repositories.DbBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Repositories.DbType
{
    public class MsSql : IDbType
    {
        private readonly string _connectionString;
        public MsSql()
        {
            _connectionString = "";
        }
        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
