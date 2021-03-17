using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DotNetCoreTemplate.Repository.MsSql
{
    public class MsSql : IMsSql
    {
        public IDbConnection GetDbConnection()
        {
            throw new NotImplementedException();
        }
    }
}
