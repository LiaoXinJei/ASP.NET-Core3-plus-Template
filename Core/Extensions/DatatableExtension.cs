using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Core
{
    public static class DataTableExtension
    {
        /// <summary>
        /// 將 DataTable 轉換成 IEnumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this DataTable dataTable) where T : class
        {
            var properties = typeof(T).GetProperties()
                .Where(x => dataTable.Columns.Contains(x.Name));

            foreach (DataRow row in dataTable.Rows)
            {
                var instance = (T)Activator.CreateInstance(typeof(T));
                foreach (var property in properties)
                {
                    var columnValue = row[property.Name];

                    if (columnValue == DBNull.Value)
                        property.SetValue(instance, null, null);
                    else
                        property.SetValue(instance, columnValue, null);
                }
                yield return instance;
            }
        }

        /// <summary>
        /// 依照泛型 Class 的 Property，改變 DataTable 的欄位型態
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable ChangeFieldType<T>(this DataTable dt) where T : class
        {
            var properties = typeof(T).GetProperties();
            var dtClone = dt.Clone();
            foreach (DataColumn column in dtClone.Columns)
            {
                var type = properties.FirstOrDefault(x => x.Name.ToUpper() == column.ColumnName.ToUpper());
                if (type == null) continue;
                column.DataType = type.PropertyType;
            }
            foreach (DataRow row in dt.Rows)
            {
                dtClone.ImportRow(row);
            }
            return dtClone;
        }
    }
}