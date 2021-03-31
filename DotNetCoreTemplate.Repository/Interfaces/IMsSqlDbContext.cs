﻿using DotNetCoreTemplate.Repository.Model;
using DotNetCoreTemplate.MsSql.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Repository.Interfaces
{
    public interface IMsSqlDbContext
    {
        IMsSqlGenericRepository<User> User { get; set; }
    }
}