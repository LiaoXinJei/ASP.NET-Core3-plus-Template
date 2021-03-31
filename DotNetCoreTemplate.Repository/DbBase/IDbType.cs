using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DotNetCoreTemplate.Repository.DbBase
{
    public interface IDbType
    {
        IDbConnection GetDbConnection();
    }
}
