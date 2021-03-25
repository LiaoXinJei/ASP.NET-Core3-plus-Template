using DotNetCoreTemplate.Repository.Interfaces;
using DotNetCoreTemplate.Repository.Model;
using DotNetCoreTemplate.Repository.MsSql.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Repository.DBContext
{
    public class MsSqlDbContext : IMsSqlDbContext
    {
        public IMsSqlGenericRepository<User> User { get; set; }
    }
}
