using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repositories.DbBase
{
    public interface IDbType
    {
        IDbConnection GetDbConnection();
    }
}
