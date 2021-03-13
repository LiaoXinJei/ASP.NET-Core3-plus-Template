using DotNetCoreTemplate.Repository.Interface;
using DotNetCoreTemplate.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Repository.DbBase
{
    public class DatabaseContext
    {
        public IGenericRepository<User> User { get; set; }
        public IGenericRepository<object> Repository{ get; set; }
    }
}
