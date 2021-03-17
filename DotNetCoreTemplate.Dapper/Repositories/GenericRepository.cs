using Dapper;
using DotNetCoreTemplate.Dapper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetCoreTemplate.Dapper.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        private readonly IDbType _dbType;
        private readonly ISqlQuery _sqlQuery;
        private readonly Type _repositoryType;
        public GenericRepository(IDbType dbType, ISqlQuery sqlQuery)
        {
            _dbType = dbType;
            _sqlQuery = sqlQuery;
            _repositoryType = typeof(T);
        }

        public void Delete(int id)
        {
            var sql = _sqlQuery.GetDeleteClause(_repositoryType) + _sqlQuery.GetWhereClause(new { id });

            DapperExcute(sql, new { id });
        }

        public void Excute(string sql, object param)
        {
            DapperExcute(sql, param);
        }

        public IEnumerable<T> GetAll()
        {
            var sql = _sqlQuery.GetSelectClause(_repositoryType);
            return DapperQuery(sql);
        }

        public T Get(int id)
        {
            var selectClause = _sqlQuery.GetSelectClause(_repositoryType);
            var whereClause = _sqlQuery.GetWhereClause(new { id });
            var sql = selectClause + whereClause;
            return DapperQuery(sql, new { id }).SingleOrDefault() ?? new T();
        }

        public IEnumerable<T> Get(object obj)
        {
            var selectClause = _sqlQuery.GetSelectClause(_repositoryType);
            var whereClause = _sqlQuery.GetWhereClause(obj);
            var sql = selectClause + whereClause;
            return DapperQuery(sql, obj);
        }

        public void Insert(T entity)
        {
            var sql = _sqlQuery.GetInsertClause(_repositoryType);
            DapperExcute(sql, entity);
        }

        public IEnumerable<T> Query(string sql, object param)
        {
            return DapperQuery(sql, param);
        }

        public void Update(T entity)
        {
            // TODO: get by id
            var sql = _sqlQuery.GetUpdateClause(_repositoryType); 
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
