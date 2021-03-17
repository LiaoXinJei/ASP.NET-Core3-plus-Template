using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Dapper.Interfaces
{
    public interface ISqlQuery
    {
        string GetDeleteClause(Type type);
        string GetWhereClause(object obj);
        string GetSelectClause(Type type);
        string GetInsertClause(Type repositoryType);
        string GetUpdateClause(Type repositoryType);
    }
}
