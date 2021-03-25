using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DotNetCoreTemplate.Repository.MsSql
{
    public class MsSql : IMsSql
    {
        // TODO: 待注入connection string
        public IDbConnection GetDbConnection()
        {
            return new SqlConnection();
        }
    }
}
