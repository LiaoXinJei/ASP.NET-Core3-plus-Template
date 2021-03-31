using Dapper;
using DotNetCoreTemplate.Repository.Attributes;
using DotNetCoreTemplate.Repository.DbBase;
using DotNetCoreTemplate.Repository.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DotNetCoreTemplate.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly IDbType _dbType;
        private readonly Type _repositoryType;

        public GenericRepository(IDbType dbType)
        {
            _dbType = dbType;
            _repositoryType = typeof(T);
        }

        public void Delete(int id)
        {
            var sql = $"DELETE FROM { _repositoryType.Name } WHERE Id = @id";

            DapperExcute(sql, new { id });
        }

        public void Excute(string sql, object param)
        {
            DapperExcute(sql, param);
        }

        public IEnumerable<T> GetAll()
        {
            var type = typeof(T);
            var tableName = type.Name;
            var sql = $"SELECT * FROM { tableName }";
            return DapperQuery(sql);
        }

        public T Get(int id)
        {
            var sql = $"SELECT * FROM { _repositoryType.Name } WHERE Id = @id";
            return DapperQuery(sql, new { id }).SingleOrDefault() ?? new T();
        }

        public IEnumerable<T> Get(object obj)
        {
            var select = $"SELECT * FROM { _repositoryType.Name } WHERE ";

            var param = obj.GetType()
                .GetProperties()
                .Select(x => {
                    if(typeof(IEnumerable).IsAssignableFrom(x.PropertyType))
                    {
                        return $"{x.Name} IN @{x.Name}";
                    }
                    else
                    {
                        return $"{x.Name} = @{x.Name}";
                    }
                });
            var whereClause = string.Join(" AND ", param);

            var sql = select + whereClause;
            return DapperQuery(sql, obj);
        }

        public void Insert(T entity)
        {
            var columns = _repositoryType.GetProperties()
                .Where(x =>
                {
                    // 找出沒有找到忽略 Attribute 的 Property.
                    var ignoreProperty = x.CustomAttributes.FirstOrDefault(y => y.AttributeType == typeof(IgnoreCreateAttribute));
                    return ignoreProperty == null;
                })
                .Select(x => x.Name);
            var param = columns.Select(x => "@" + x);
            var sql = $"INSERT INTO { _repositoryType.Name }({ string.Join(", ", columns) }) VALUES({ string.Join(", ", param) })";
            DapperExcute(sql, entity);
        }

        public IEnumerable<T> Query(string sql, object param)
        {
            return DapperQuery(sql, param);
        }

        public void Update(T entity)
        {
            var columns = _repositoryType.GetProperties()
                .Where(x =>
                {
                    // 找出沒有找到忽略 Attribute 的 Property.
                    var ignoreProperty = x.CustomAttributes.FirstOrDefault(y => y.AttributeType == typeof(PrimaryKeyAttribute) || y.AttributeType == typeof(IgnoreUpdateAttribute));
                    return ignoreProperty == null;
                })
                .Select(x => $"{ x.Name } = @{ x.Name }");

            var sql = $"UPDATE { _repositoryType.Name } SET { string.Join(", ", columns) } WHERE Id = @id";
            DapperExcute(sql, entity);
        }

        private IEnumerable<T> DapperQuery(string sql, object param = null)
        {
            using (var conn = _dbType.GetDbConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    var result = conn.Query<T>(sql, param);
                    tran.Commit();
                    return result;
                }
            }
        }

        private void DapperExcute(string sql, object param = null)
        {
            using (var conn = _dbType.GetDbConnection())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    conn.Execute(sql, param);
                    tran.Commit();
                }
            }
        }
    }
}
