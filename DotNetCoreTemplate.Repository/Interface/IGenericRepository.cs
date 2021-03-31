using DotNetCoreTemplate.Repository.DbBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreTemplate.Repository.Interface
{
    /// <summary>
    /// 尚未切開各資料庫傳遞參數，或是資料庫命名限制等等問題(EX: Postgresql 不可用大寫，因此在欄位命名上會與C#命名不同)
    /// 暫時僅能使用 Mssql
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
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
