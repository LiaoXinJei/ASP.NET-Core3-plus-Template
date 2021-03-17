using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DotNetCoreTemplate.Dapper.Interfaces
{
    public interface IDbType
    {
        IDbConnection GetDbConnection();
    }
}
