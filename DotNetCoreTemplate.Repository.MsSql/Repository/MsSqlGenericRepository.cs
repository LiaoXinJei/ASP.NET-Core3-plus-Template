using DotNetCoreTemplate.Dapper;
using DotNetCoreTemplate.Dapper.Interfaces;
using DotNetCoreTemplate.Dapper.Repositories;
using DotNetCoreTemplate.Repository.MsSql.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Repository.MsSql.Repository
{
    public class MsSqlGenericRepository<T> : GenericRepository<T>, IMsSqlGenericRepository<T> where T : BaseEntity, new()
    {
        public MsSqlGenericRepository(IMsSql dbType, IMsSqlSqlQuery sqlQuery) : base(dbType, sqlQuery)
        {
        }
    }
}
