using Repositories.DbBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> Query(string sql, object param);
        void Excute(string sql, object param);
    }
}
