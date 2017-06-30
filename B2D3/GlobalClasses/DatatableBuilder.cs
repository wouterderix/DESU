using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace B2D3.GlobalClasses
{
    public static class DatatableBuilder
    {
        /// <summary>
        /// Builds a datatable based on all properties on the given object.
        /// </summary>
        /// <typeparam name="T">The type of the object in the collection.</typeparam>
        /// <param name="objects">A collection of data to fill the datatable with.</param>
        /// <returns></returns>
        public static DataTable BuildDatatable<T>(IEnumerable<T> objects)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }

            foreach (T tObject in objects)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                { values[i] = Props[i].GetValue(tObject, null); }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}