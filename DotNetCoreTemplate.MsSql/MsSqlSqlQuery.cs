using DotNetCoreTemplate.Dapper;
using DotNetCoreTemplate.Dapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetCoreTemplate.MsSql
{
    public class MsSqlSqlQuery : IMsSqlSqlQuery
    {
        public string GetDeleteClause(Type type)
        {
            return $"DELETE FROM { type.Name }";
        }

        public string GetInsertClause(Type type)
        {
            var columns = type.GetProperties()
                .Where(x =>
                {
                    var ignoreProperty = x.CustomAttributes
                        .FirstOrDefault(y => y.AttributeType == typeof(IgnoreCreateAttribute));
                    return ignoreProperty == null;
                })
                .Select(x => x.Name);
            var param = columns.Select(x => "@" + x);
            var sql = $"INSERT INTO { type.Name }({ string.Join(", ", columns) }) VALUES({ string.Join(", ", param) })";
            return sql;

        }

        public string GetSelectClause(Type type)
        {
            var tableName = type.Name;
            return $"SELECT * FROM { tableName }";
        }

        public string GetUpdateClause<T>(T entity) where T : BaseEntity
        {
            var type = entity.GetType();

            var columns = type.GetProperties()
                .Where(x => x.GetValue(entity, null) != null)
                .Where(x =>
                {
                    var ignoreProperty = x.CustomAttributes
                        .FirstOrDefault(y => y.AttributeType == typeof(PrimaryKeyAttribute)
                          || y.AttributeType == typeof(IgnoreUpdateAttribute));
                    return ignoreProperty == null;
                })
                .Select(x => $"{ x.Name } = @{ x.Name }");

            var sql = $"UPDATE { type.Name } SET { string.Join(", ", columns) }";
            return sql;
        }

        public string GetWhereClause(object obj)
        {
            var param = obj.GetType()
                .GetProperties()
                .Select(x => $"{x.Name} = @{x.Name}");
            var whereClause = string.Join(" AND ", param);
            return $"WHERE { whereClause }";
        }
    }
}
