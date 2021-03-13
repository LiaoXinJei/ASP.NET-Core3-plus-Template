using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace DotNetCoreTemplate.Core.Extensions
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// 將 IEnumerable 轉換為 DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> enumerable) where T : class
        {
            var properties = typeof(T).GetProperties();
            var columns = properties.Select(property =>
            {
                var attr = property.GetCustomAttributes(false).FirstOrDefault(y => y.GetType() == typeof(ColumnAttribute)) as ColumnAttribute;
                return new
                {
                    Key = property.Name,
                    Value = attr == null ? property.Name : attr.Name,
                };
            });
            var dt = new DataTable();
            foreach (var column in columns)
            {
                dt.Columns.Add(column.Value);
            }

            foreach (var item in enumerable)
            {
                var row = dt.NewRow();
                foreach (var property in item.GetType().GetProperties())
                {
                    var value = property.GetValue(item, null);
                    var column = columns.First(x => x.Key == property.Name).Value;
                    row[column] = value;
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}