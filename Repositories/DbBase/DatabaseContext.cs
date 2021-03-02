using Repositories.Interface;
using Repositories.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.DbBase
{
    public class DatabaseContext
    {
        public IGenericRepository<User> User { get; set; }
        public IGenericRepository<dynamic> Repository{ get; set; }
    }
}
