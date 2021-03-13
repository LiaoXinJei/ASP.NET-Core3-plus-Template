using Dapper;
using Repositories.DbBase;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly IDbType _dbType;

        public GenericRepository(IDbType dbType)
        {
            _dbType = dbType;
        }

        public void Delete(int id)
        {
            var type = typeof(T);
            var tableName = type.Name;
            var sql = $"DELETE FROM { tableName } WHERE Id = @id";

            DapperExcute(sql, new { id });
        }

        public void Excute(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            var type = typeof(T);
            var tableName = type.Name;
            var sql = $"SELECT * FROM { tableName }";
            return DapperQuery(sql);
        }

        public T GetById(int id)
        {
            var type = typeof(T);
            var tableName = type.Name;
            var sql = $"SELECT * FROM { tableName } WHERE Id = @id";
            return DapperQuery(sql, new { id }).SingleOrDefault() ?? new T();
        }

        public void Insert(T entity)
        {
            var type = typeof(T);
            var tableName = type.Name;
            var columns = type.GetProperties()
                .Select(x => x.Name);
            var param = columns.Select(x => "@" + x);
            var sql = $"INSERT INTO { tableName }({ string.Join(", ", columns) }) VALUES({ string.Join(", ", param) })";
            DapperExcute(sql, entity);
        }

        public IEnumerable<T> Query(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            var type = typeof(T);
            var tableName = type.Name;
            var columns = type.GetProperties()
                .Where(x => x.Name.ToUpper() != "ID" || x.Name.ToUpper() != "GUID") // TODO: update type attribute
                .Select(x => $"{ x.Name } = @{ x.Name }");

            var sql = $"UPDATE { tableName } SET { string.Join(", ", columns) } WHERE Id = @id";
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
                    var result = conn.Execute(sql, param);
                    tran.Commit();
                }
            }
        }
    }
}
