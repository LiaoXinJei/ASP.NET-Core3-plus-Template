using DotNetCoreTemplate.Dapper.Interfaces;
using DotNetCoreTemplate.Dapper.Repositories;
using DotNetCoreTemplate.Repository.MsSql.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Repository.MsSql.Repository
{
    public class MsSqlGenericRepositor<T> : GenericRepository<T>, IMsSqlGenericRepository<T> where T : class, new()
    {
        public MsSqlGenericRepositor(IDbType dbType, ISqlQuery sqlQuery) : base(dbType, sqlQuery)
        {
        }
    }
}
