using Dapper;
using Repositories.DbBase;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Repositories.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private string _connectionString;
        public GenericRepository()
        {
            _connectionString = "";
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Excute(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query(string sql, object param)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<T> DapperQuery(string sql, object param)
        {
            using (var conn = new SqlConnection(_connectionString))
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

        private void DapperExcute(string sql, object param)
        {
            using (var conn = new SqlConnection(_connectionString))
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
