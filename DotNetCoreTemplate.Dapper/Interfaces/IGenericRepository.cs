using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Dapper.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Get(object obj);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> Query(string sql, object param);
        void Excute(string sql, object param);
    }
}
