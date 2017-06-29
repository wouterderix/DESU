using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Reflection;

namespace B2D3.Classes
{
    public partial class WorkItem
    {


        public DataTable FetchTable()
        {
            DataTable dt = new DataTable();
            List<WorkItem> wi = new List<WorkItem>();

            using (var db = new Casusblok5Model())
            {
                var result = from w in db.WorkItems
                             orderby w.ID
                             select w;

                foreach (var item in result)
                {
                    wi.Add(item);
                }
            }

            //return dt = DTConverter<WorkItem>(wi);
            return dt = BuildDatatable<WorkItem>(wi);
        }

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

        //public DataTable DTConverter<T>(List<T> items)
        //{
        //    DataTable dataTable = new DataTable(typeof(T).Name);

        //    //Get all the properties
        //    PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    foreach (PropertyInfo prop in Props)
        //    {
        //        //Defining type of data column gives proper data table 
        //        var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
        //        //Setting column names as Property names
        //        dataTable.Columns.Add(prop.Name, type);
        //    }
        //    foreach (T item in items)
        //    {
        //        var values = new object[Props.Length];
        //        for (int i = 0; i < Props.Length; i++)
        //        {
        //            //inserting property values to datatable rows
        //            values[i] = Props[i].GetValue(item, null);
        //        }
        //        dataTable.Rows.Add(values);
        //    }
        //    //put a breakpoint here and check datatable
        //    return dataTable;
        //}


    }
